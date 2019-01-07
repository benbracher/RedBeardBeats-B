using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedStarter.Database.Contexts;
using RedStarter.Database.DataContract.Authorization.Interfaces;
using RedStarter.Database.DataContract.Authorization.RAOs;
using RedStarter.Database.Entities.People;
using System;
using System.Threading.Tasks;

namespace RedStarter.Database.Authorization
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly SISContext _context;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;


        public AuthRepository(IMapper mapper, SISContext context, 
                UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ReceivedExistingUserRAO> Login(QueryForExistingUserRAO queryRao)
        {
            var user = await _userManager.FindByNameAsync(queryRao.UserName);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, queryRao.Password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.Users
                  .FirstOrDefaultAsync(u => u.NormalizedUserName == queryRao.UserName.ToUpper());

                return _mapper.Map<ReceivedExistingUserRAO>(appUser);
            }

            throw new NotImplementedException();
        }

        public async Task<ReceivedExistingUserRAO> Register(RegisterUserRAO regUserRAO, string password)
        {
            var user = _mapper.Map<UserEntity>(regUserRAO);

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var rao = _mapper.Map<ReceivedExistingUserRAO>(user);
                return rao;
            }
            throw new NotImplementedException("User already exists");
        }

        public async Task<bool> UserExists(string username)
        {
            var query = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            if (query != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ReceivedExistingUserRAO> GetUserById(int ownerId)
        {
            var query = await _context.UserTableAccess.FirstOrDefaultAsync(u => u.Id == ownerId);

            var user = _mapper.Map<ReceivedExistingUserRAO>(query);

            return user;
        }
    }
}