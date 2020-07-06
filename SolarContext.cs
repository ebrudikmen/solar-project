using Microsoft.EntityFrameworkCore;
using SolarProject.Models;

namespace SolarProject
{
    public class SolarContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Product> Products { get; set; }

        public SolarContext(DbContextOptions<SolarContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}