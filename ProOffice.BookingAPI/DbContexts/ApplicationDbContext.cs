using Microsoft.EntityFrameworkCore;
using ProOffice.BookingAPI.Models;

namespace ProOffice.BookingAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
    }
}
