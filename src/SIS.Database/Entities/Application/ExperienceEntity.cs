using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RedStarter.Database.Entities.Application
{
    public class ExperienceEntity
    {
        [Key]
        public Guid ApplicationEntityId { get; set; }

        public string EmploymentStatus { get; set; }
        public string IncomeLevel { get; set; }
    }
}
