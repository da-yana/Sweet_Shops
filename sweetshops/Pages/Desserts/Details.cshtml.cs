using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sweetshops.Data;
using sweetshops.Model;

namespace sweetshops.Pages.Desserts
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Dish? Dish { get; set; }

        public IActionResult OnGet(int id)
        {
            Dish = _context.Dishes
                        .Where(c => c.Id == id)
                        .Include(b => b.GroupDish)
                        .FirstOrDefault();

            if (Dish == null)
                return NotFound();

            return Page();
        }
    }
}
