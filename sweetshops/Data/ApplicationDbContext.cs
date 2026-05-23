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
        public DbSet<GroupDish> GroupDishes { get; set; }  // ← ИЗМЕНИТЬ название

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка связи Dish → GroupDish
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.GroupDish)
                .WithMany(g => g.Dishes)  // если в GroupDish есть коллекция Dishes
                .HasForeignKey(d => d.GroupDishId)  // нужно добавить внешний ключ
                .OnDelete(DeleteBehavior.Restrict);  // избегаем каскадных удалений

            modelBuilder.Entity<GroupDish>().HasData(
                new GroupDish { Id = 1, Name = "Сладкое" },  // ← исправьте опечатку "Слдакое"
                new GroupDish { Id = 2, Name = "Мясное" },
                new GroupDish { Id = 3, Name = "Мучное" }
            );
        }
    }
}