using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.DataContract.Application
{
    public class ContactRAO
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
