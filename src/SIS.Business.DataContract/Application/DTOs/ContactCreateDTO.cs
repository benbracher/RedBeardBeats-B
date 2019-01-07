using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Application.DTOs
{
    public class ContactCreateDTO
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
