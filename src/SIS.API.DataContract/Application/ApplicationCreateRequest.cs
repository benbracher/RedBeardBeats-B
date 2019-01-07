using System.ComponentModel.DataAnnotations;

namespace RedStarter.API.DataContract.Application
{
    public class ApplicationCreateRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ContactCreateRequest Contact { get; set; }
        public DemographicCreateRequest Demographic { get; set; }
        public EducationCreateRequest Education { get; set; }
        public ExperienceCreateRequest Experience { get; set; }
    }
}

