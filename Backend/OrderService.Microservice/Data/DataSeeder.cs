using OrderService.Microservice.Context;
using OrderService.Microservice.Model;

namespace OrderService.Microservice.Data
{
    public static class DataSeeder
    {
        //class for testing
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<OrderDbContext>());
            }

        }

        private static void SeedData(OrderDbContext context)
        {
            if (!context.Bid.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Bid.AddRange(
                    new Bid() { bidAmount = 50.3, created = new DateTime(2022, 5, 25, 15, 16, 00), Id = 1, productId = 1, userId = 1}
                    );
                context.SaveChanges();
            }
            else
            {
                Console.Write("--> we already have data");
            }
        }
    }
}
