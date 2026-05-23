using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sweetshops.Data;
using sweetshops.Model;

namespace sweetshops.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            // ИСПРАВЛЕННЫЙ КОД - убираем ссылку на Dishs
            var dish = new Dish
            {
                Title = "Clean Code",
                DishName = "Название блюда",  // добавьте обязательные поля
                GroupDishId = 1  // например, ссылка на группу "Сладкое"
            };

            _context.Dishes.Add(dish);
            _context.SaveChanges();

            var dishes = _context.Dishes.ToList();  // переименовал Dishs → dishes
        }
    }
}