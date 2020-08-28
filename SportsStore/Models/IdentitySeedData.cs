using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var scopedFactory = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopedFactory.CreateScope())
            {
                var userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();

                IdentityUser user = await userManager.FindByNameAsync(adminUser);
                if (user == null)
                {
                    user = new IdentityUser(adminUser);
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
        }
    }
}
