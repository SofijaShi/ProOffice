using Microsoft.EntityFrameworkCore;
using ProOffice.ResourceAPI.Models;

namespace ProOffice.ResourceAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Resource>().HasData(new Resource
            {
                Id = 1,
                Name = "Resource1",
                Quantity = 10,
            });
            modelBuilder.Entity<Resource>().HasData(new Resource
            {
                Id = 2,
                Name = "Resource2",
                Quantity = 3,
            });
            modelBuilder.Entity<Resource>().HasData(new Resource
            {
                Id = 3,
                Name = "Resource3",
                Quantity = 100,
            });
        }
    }
}
