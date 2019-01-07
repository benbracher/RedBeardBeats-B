using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RedStarter.API.DataContract.Authorization;
using RedStarter.Business.DataContract.Authorization;
using RedStarter.Business.DataContract.Authorization.DTOs;
using RedStarter.Business.DataContract.Authorization.Interfaces;
using RedStarter.Database.DataContract.Authorization.RAOs;
using RedStarter.Database.Entities.People;

namespace RedStarter.API.Controllers.Authorization
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly UserManager<UserEntity> _userManager;

        public AuthController(IConfiguration config, IMapper mapper, IAuthManager authManager, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _config = config;
            _authManager = authManager;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest userForRegister)
        {
            var userDTO = _mapper.Map<RegisterUserDTO>(userForRegister);

            var returnedUser = await _authManager.RegisterUser(userDTO);

            var appUser = await _userManager.Users
              .FirstOrDefaultAsync(u => u.NormalizedUserName == userDTO.UserName.ToUpper());

            var userResponse = _mapper.Map<ReceivedExistingUserResponse>(appUser);

            if (userResponse != null)
            {
                return Ok(new
                {
                    token = GenerateTokenString(appUser).Result,
                    user = userResponse
                });
            }

            return BadRequest("Bad Request");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest loginUserRequest)
        {
            var userDTO = _mapper.Map<QueryForExistingUserDTO>(loginUserRequest);

            var returnedUser = await _authManager.LoginUser(userDTO);

            var appUser = await _userManager.Users
                  .FirstOrDefaultAsync(u => u.NormalizedUserName == userDTO.UserName.ToUpper());

            var userResponse = _mapper.Map<ReceivedExistingUserResponse>(appUser);

            if(userResponse != null)
            {
                return Ok(new
                {
                    token = GenerateTokenString(appUser).Result,
                    user = userResponse
                });
            }

            return Unauthorized();
        }



        [HttpGet("userExists")]
        public async Task<IActionResult> UserExists(string email)
        {
            var userExists = await _authManager.UserExists(email);

            if (userExists)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        private async Task<string> GenerateTokenString(UserEntity user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}