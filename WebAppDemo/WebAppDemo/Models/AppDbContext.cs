using Microsoft.EntityFrameworkCore;

namespace WebAppDemo.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Customer>Customer { get; set; }

        public DbSet<Customer> dpfile { get; set; }

        public DbSet<Customer> userNAme { get; set; }
    }
}
