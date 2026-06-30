using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sweetshops.Data;
using sweetshops.Model;
using sweetshops.Model.AuthApp;

namespace sweetshops.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProfileModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public AuthUser CurrentUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _context.AuthUsers.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            CurrentUser = user;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _context.AuthUsers.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            if (user == null) return NotFound();

            return RedirectToPage();
        }
    }
}