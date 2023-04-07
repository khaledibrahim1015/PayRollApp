using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PayCompute.Persistence
{
    public static class DataSeedingInitializer
    {
        public static async Task UserAndRoleSeedAsync(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)

        {
            // Roles

            string[] Roles = { "Admin", "Manager", "Staff" };

            foreach (var Role in Roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(Role);

                if (roleExist == false)
                {

                    await roleManager.CreateAsync(new IdentityRole(Role));

                }

            }

            if (userManager.FindByEmailAsync("khaled.ibrahem.ahmed.ali@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = "khaled.ibrahem.ahmed.ali@gmail.com",
                    UserName = "khaled.ibrahem.ahmed.ali@gmail.com"

                };

                IdentityResult identityResult = userManager.CreateAsync(user, "Admin123@").Result;
                if (identityResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");

                }



            }

            if (userManager.FindByEmailAsync("ibrahimkhaled136@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = "ibrahimkhaled136@gmail.com",
                    UserName = "ibrahimkhaled136@gmail.com"

                };

                IdentityResult identityResult = userManager.CreateAsync(user, "Manager123@").Result;
                if (identityResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Manager");

                }



            }

            if (userManager.FindByEmailAsync("staff@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = "staff@gmail.com",
                    UserName = "staff@gmail.com"

                };

                IdentityResult identityResult = userManager.CreateAsync(user, "Staff123@").Result;
                if (identityResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Staff");

                }



            }


        }
    }
}
