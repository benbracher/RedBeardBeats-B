using AutoMapper;
using RedStarter.Business.DataContract.Application.DTOs;
using RedStarter.Business.DataContract.Application.Interfaces;
using RedStarter.Database.DataContract.Application;
using RedStarter.Database.DataContract.Authorization.Interfaces;
using RedStarter.Database.DataContract.Roles.Interfaces;
using System;
using System.Threading.Tasks;

namespace RedStarter.Business.Managers.Application
{
    public class UserApplicationManager : IUserApplicationManager
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IRoleRepository _roleRepository;

        public UserApplicationManager(IMapper mapper, IApplicationRepository applicationRepository, IAuthRepository authRepository, IRoleRepository roleRepository)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _authRepository = authRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> CreateApplication(ApplicationCreateDTO applicationDTO)
        {
            var user = await _authRepository.GetUserById(applicationDTO.OwnerId);

            if (applicationDTO.OwnerId != user.Id)
                throw new Exception("Unauthorized"); //TODO: Adjustments

            var rao = _mapper.Map<ApplicationCreateRAO>(applicationDTO);

            rao.OwnerId = applicationDTO.OwnerId;

            Guid ApplicationGuid = Guid.NewGuid();
            
            await _roleRepository.AddUserToRole(user, "User");
            return true;
              
        }
    }
}
