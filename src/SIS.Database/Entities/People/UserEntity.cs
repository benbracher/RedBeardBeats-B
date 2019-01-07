using Microsoft.AspNetCore.Identity;
using RedStarter.Database.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.Entities.People
{
    public class UserEntity : IdentityUser<int>
    {
        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
