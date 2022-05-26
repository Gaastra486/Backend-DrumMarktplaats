using AccountService.Microservice.Context;
using AccountService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Microservice.Data
{
    public static class DataSeeder
    {
        /*private readonly UserDbContext _userDbContext;

        public DataSeeder(UserDbContext userDbContext)
        {
            this._userDbContext = userDbContext;
        }*/

        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<UserDbContext>());
            }
        }
        public static void SeedData(UserDbContext userDbContext)
        {
            Console.WriteLine("--> Attempting to apply migrations...");
            try
            {
               userDbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            }
            
            if (!userDbContext.User.Any())
            {
                var user = new List<UserModel>()
                {
                    new UserModel()
                    {
                        Username = "Chaim",
                        Password = "1234",
                        Email = "c@gmail.com",
                        Postalcode = "5398BL"
                    }
                };
                userDbContext.User.AddRange(user);
                userDbContext.SaveChanges();   
            }
        }
    }
}
