using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Data
{
    public class SeedAdminData
    {
        public static void Seed(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if(userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    NormalizedUserName = "admin",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    
                };
                var result = userManager.CreateAsync(user, "Admin1$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.CreateAsync(role);
            }
        }
    }
}
