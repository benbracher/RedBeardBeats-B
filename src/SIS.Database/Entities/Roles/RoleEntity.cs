using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.Entities.Roles
{
    public class RoleEntity : IdentityRole<int>
    {
        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
