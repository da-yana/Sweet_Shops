using Microsoft.EntityFrameworkCore;
using sweetshops.Model;
using sweetshops.Model.AuthApp;

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
        public DbSet<GroupDish> GroupDishes { get; set; }  
        public DbSet<AuthUser> AuthUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.GroupDish)
                .WithMany(g => g.Dishes)  
                .HasForeignKey(d => d.GroupDishId)  
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<GroupDish>().HasData(
                new GroupDish { Id = 1, Name = "Сладкое" },  
                new GroupDish { Id = 2, Name = "Мясное" },
                new GroupDish { Id = 3, Name = "Мучное" }
            );
        }
    }
}