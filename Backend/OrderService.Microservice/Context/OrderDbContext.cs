using Microsoft.EntityFrameworkCore;
using OrderService.Microservice.Model;

namespace OrderService.Microservice.Context
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext()
        {

        }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Bid> Bid { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }*/
    }
}
