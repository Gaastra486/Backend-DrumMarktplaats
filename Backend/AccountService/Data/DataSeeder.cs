using AccountService.Microservice.Context;
using AccountService.Models;

namespace AccountService.Microservice.Data
{
    public static class DataSeeder
    {
        //private readonly UserDbContext _userDbContext;

      /*  public DataSeeder(UserDbContext userDbContext)
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
            if (!userDbContext.User.Any())
            {
                var user = new List<UserModel>()
                {
                    new UserModel()
                    {
                        Username = "Chaim",
                        Password = "1234",
                        Id = 1,
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
