using Microsoft.EntityFrameworkCore;
using sweetshops.Model;

namespace sweetshops.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}
