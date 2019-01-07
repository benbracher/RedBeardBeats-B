using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Application
{
    public class ContactCreateRequest
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
