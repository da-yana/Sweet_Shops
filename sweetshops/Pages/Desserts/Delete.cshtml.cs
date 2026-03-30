using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sweetshops.Data;
using sweetshops.Model;

namespace sweetshops.Pages.Desserts
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dish Dish { get; set; }

        public IActionResult OnGet(int id)
        {
            Dish = _context.Dishes
                        .Where(c => c.Id == id)
                        .Include(b => b.CategoriesDish)
                        .FirstOrDefault();

            if (Dish == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var dish = _context.Dishes.Find(Dish.Id);

            if (dish != null)
            {
                _context.Dishes.Remove(dish);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
