using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.DataContract.Application
{
    public class ApplicationCreateRAO 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactRAO Contact { get; set; }
        public DemographicRAO Demographic { get; set; }
        public EducationRAO Education { get; set; }
        public ExperienceRAO Experience { get; set; }

        public int OwnerId { get; set; } //TODO: GUID?
    }
}
