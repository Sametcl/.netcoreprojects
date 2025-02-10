using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin";
        private const string adminPassword = "Admin_123";


        public static async void IdentityTestUser(IApplicationBuilder app)
        {
            var context= app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();

            if (context.Database.GetAppliedMigrations().Any() ) 
            {
                context.Database.Migrate();
            }


            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var user=await userManager.FindByNameAsync( adminUser );

            if (user == null)
            {
                user = new AppUser
                {
                    Fullname = "Samet Çil",
                    UserName = adminUser,
                    Email = "admin@sametcil.com",
                    PhoneNumber = "2222222222222",
                    
                    
                };

                await userManager.CreateAsync( user ,adminPassword);
            }
        }
    }
}
