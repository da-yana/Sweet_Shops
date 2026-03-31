using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sweetshops.Data;
using sweetshops.Model;

namespace sweetshops.Pages.Desserts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;


        public EditModel(ApplicationDbContext context)
        {
            _context = context;

        }

        [BindProperty]
        public Dish Dish { get; set; }

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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Dishes.Update(Dish);
            _context.SaveChanges();



            return RedirectToPage("Index");
        }
    }
}
