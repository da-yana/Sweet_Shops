using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sweetshops.Data;
using sweetshops.Model;

namespace sweetshops.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Clients { get; set; }

        public IActionResult OnGet(int id)
        {
            Clients = _context.Clients.Find(id);

            if (Clients == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var student = _context.Clients.Find(Clients.Id);

            if (student != null)
            {
                _context.Clients.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
