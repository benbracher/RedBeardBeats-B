using Microsoft.AspNetCore.Identity;
using RedStarter.Database.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.Entities.Roles
{
    public class UserRoleEntity : IdentityUserRole<int>
    {
        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
