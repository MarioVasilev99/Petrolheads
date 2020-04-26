namespace Petrolheads.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Petrolheads.Common;
    using Petrolheads.Data.Models;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider
                            .GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync("admin");

            if (user != null)
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
            };

            var password = "admin123";

            var result = await userManager.CreateAsync(adminUser, password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, GlobalConstants.AdministratorRoleName);
            }


        }
    }
}
