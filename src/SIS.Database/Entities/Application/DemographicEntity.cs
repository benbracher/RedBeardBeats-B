using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RedStarter.Database.Entities.Application
{
    public class DemographicEntity
    {
        [Key]
        public Guid ApplicationEntityId { get; set; }

        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public bool Married { get; set; }
    }
}
