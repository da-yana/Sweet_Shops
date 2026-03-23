using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sweetshops.Data;
using sweetshops.Model;

namespace sweetshops.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Client Client { get; set; }
        public IActionResult OnGet(int id)
        {
            Client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (Client == null)
                return NotFound();
            return Page();
        }
    }
}
