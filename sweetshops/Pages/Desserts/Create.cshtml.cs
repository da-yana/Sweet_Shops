using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sweetshops.Data;
using sweetshops.Model;

namespace sweetshops.Pages.Desserts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dish Dish { get; set; }

        // Свойство для выпадающего списка
        public SelectList GroupDishesList { get; set; }

        public void OnGet()
        {
            // Загружаем группы блюд из базы, исключая пустые и мусорные записи
            var groupDishes = _context.GroupDishes
                .Where(g => g.Name != null
                    && g.Name.Trim() != ""
                    && g.Name != "макароны"
                    && g.Name != "макароны")
                .OrderBy(g => g.Name)
                .ToList();

            GroupDishesList = new SelectList(groupDishes, nameof(GroupDish.Id), nameof(GroupDish.Name));
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Если ошибка - перезагружаем список групп (с фильтрацией)
                var groupDishes = _context.GroupDishes
                    .Where(g => g.Name != null
                        && g.Name.Trim() != ""
                        && g.Name != "макароны")
                    .OrderBy(g => g.Name)
                    .ToList();

                GroupDishesList = new SelectList(groupDishes, nameof(GroupDish.Id), nameof(GroupDish.Name));
                return Page();
            }

            _context.Dishes.Add(Dish);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}