using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using RedStarter.Database.DataContract.SeedData;
using RedStarter.Database.Entities.People;
using RedStarter.Database.Entities.Roles;

namespace RedStarter.Database.SeedData
{
    public class SeedRepository : ISeedRepository
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<RoleEntity> _roleManager;

        public SeedRepository(UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                var roles = new List<RoleEntity>
                {
                    new RoleEntity{Name = "User"},
                    new RoleEntity{Name = "Admin"},
                    new RoleEntity{Name = "Guest"},
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                var adminUser = new UserEntity { UserName = "admin" };
                var user = new UserEntity { UserName = "user" };
                var guest = new UserEntity { UserName = "guest" };

                #region
                IdentityResult adminResult = _userManager.CreateAsync(adminUser, "password").Result;
                IdentityResult userResult = _userManager.CreateAsync(user, "password").Result;
                IdentityResult guestResult = _userManager.CreateAsync(guest, "password").Result;

                #endregion
                if (adminResult.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("admin").Result;
                    _userManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();
                }
                if (userResult.Succeeded)
                {
                    var applicant = _userManager.FindByNameAsync("user").Result;
                    _userManager.AddToRolesAsync(applicant, new[] { "User" }).Wait();
                }
                if (guestResult.Succeeded)
                {
                    var applicant = _userManager.FindByNameAsync("guest").Result;
                    _userManager.AddToRolesAsync(applicant, new[] { "Guest" }).Wait();
                }

            }
        }
    }
}