using WeatherWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace WeatherWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<City> cities { get; set; }
        public DbSet<Favorite> favorites { get; set; }
    }
}
