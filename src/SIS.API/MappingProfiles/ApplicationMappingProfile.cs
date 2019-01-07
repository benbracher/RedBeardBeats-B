using AutoMapper;
using RedStarter.API.DataContract.Application;
using RedStarter.Business.DataContract.Application.DTOs;
using RedStarter.Database.DataContract.Application;
using RedStarter.Database.Entities.Application;

namespace RedStarter.API.MappingProfiles
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            //<-- Registration-oriented
            CreateMap<ApplicationCreateRequest, ApplicationCreateDTO>(); 
            CreateMap<ApplicationCreateDTO, ApplicationCreateRAO>();     
            CreateMap<ApplicationCreateRAO, ApplicationEntity>();
            CreateMap<ContactRAO, ContactEntity>();
            CreateMap<DemographicRAO, DemographicEntity>();
            CreateMap<EducationRAO, EducationEntity>();
            CreateMap<ExperienceRAO, ExperienceEntity>();
        }
    }
}
