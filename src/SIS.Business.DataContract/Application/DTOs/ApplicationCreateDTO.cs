namespace RedStarter.Business.DataContract.Application.DTOs
{
    public class ApplicationCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ContactCreateDTO Contact { get; set; }
        public DemographicCreateDTO Demographic { get; set; }
        public EducationCreateDTO Education { get; set; }
        public ExperienceCreateDTO Experience { get; set; }

        public int OwnerId { get; set; }
    }
}

