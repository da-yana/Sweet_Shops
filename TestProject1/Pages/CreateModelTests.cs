using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sweetshops.Data;
using sweetshops.Model;

namespace sweetshops.Test.UnitTests.Pages
{
    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void Test11_RazorPageModel_WithValidDish_ShouldCreateDish()
        {
            // Arrange
            var context = GetDbContext();
            var groupDish = new GroupDish { Name = "Супы" };
            context.GroupDishes.Add(groupDish);
            context.SaveChanges();

            var pageModel = new RazorPageModelWithDish(context);
            pageModel.Dish = new Dish
            {
                DishName = "Борщ",
                Price = 350.50m,
                DescriptionDish = "Традиционный украинский борщ",
                Ingredients = "Свекла, капуста, картофель",
                CookingTimeMinutes = 60,
                GroupDishId = groupDish.Id
            };

            // Act
            var result = pageModel.OnPost();

            // Assert
            result.Should().BeOfType<RedirectToPageResult>();
            context.Dishes.Count().Should().Be(1);
            var createdDish = context.Dishes.First();
            createdDish.DishName.Should().Be("Борщ");
        }
    }

    public class RazorPageModelWithDish : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RazorPageModelWithDish(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dish Dish { get; set; } = new Dish();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dishes.Add(Dish);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}