using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedStarter.API.DataContract.Application;
using RedStarter.Business.DataContract.Application.DTOs;
using RedStarter.Business.DataContract.Application.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RedStarter.API.Controllers.Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUserApplicationManager _applicationCreateManager;
        private readonly IMapper _mapper;

        public ApplicationController(IUserApplicationManager applicationCreateManager, IMapper mapper)
        {
            _applicationCreateManager = applicationCreateManager;
            _mapper = mapper;
        }

        [HttpPost] 
        public async Task<IActionResult> PostApplication(ApplicationCreateRequest applicationCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); 

            var dto = _mapper.Map<ApplicationCreateDTO>(applicationCreateRequest);
            dto.OwnerId = identityClaimNum;

            var created = await _applicationCreateManager.CreateApplication(dto);

            if (created)
                return StatusCode(201); //TODO: Return URL of new resource

            return StatusCode(500);
        }
    }
}

