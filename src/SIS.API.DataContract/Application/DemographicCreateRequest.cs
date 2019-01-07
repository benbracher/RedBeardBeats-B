using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Application
{
    public class DemographicCreateRequest
    {
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public bool Married { get; set; }
    }
}
