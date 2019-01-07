using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Application.DTOs
{
    public class DemographicCreateDTO
    {
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public bool Married { get; set; }
    }
}
