using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedStarter.Database.Contexts;
using RedStarter.Database.DataContract.Application;
using RedStarter.Database.Entities.Application;
using RedStarter.Database.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.Application
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly SISContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public ApplicationRepository(SISContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateApplication(ApplicationCreateRAO applicationCreate, Guid ApplicationGuid)
        {
            var applicationEntity = _mapper.Map<ApplicationEntity>(applicationCreate);
            applicationEntity.DateCreated = DateTime.Now;
            applicationEntity.ApplicationEntityId = ApplicationGuid;

            var contactEntity = _mapper.Map<ContactEntity>(applicationCreate.Contact);
            contactEntity.ApplicationEntityId = ApplicationGuid;

            var demographicEntity = _mapper.Map<DemographicEntity>(applicationCreate.Demographic);
            demographicEntity.ApplicationEntityId = ApplicationGuid;

            var educationEntity = _mapper.Map<EducationEntity>(applicationCreate.Education);
            educationEntity.ApplicationEntityId = ApplicationGuid;

            var experienceEntity = _mapper.Map<ExperienceEntity>(applicationCreate.Experience);
            experienceEntity.ApplicationEntityId = ApplicationGuid;

            await _context.ApplicationTableAccess.AddAsync(applicationEntity);
            await _context.ContactTableAccess.AddAsync(contactEntity);
            await _context.DemographicTableAccess.AddAsync(demographicEntity);
            await _context.EducationTableAccess.AddAsync(educationEntity);
            await _context.ExperienceTableAccess.AddAsync(experienceEntity);

            return await _context.SaveChangesAsync() == 6;
        }

        public async Task<IEnumerable<ApplicationListItemRAO>> GetAllApplications()
        {
            var EntityList = await _context.ApplicationTableAccess.ToArrayAsync();
            var List = _mapper.Map<IEnumerable<ApplicationListItemRAO>>(EntityList);
           
            return List;
        }
    }
}