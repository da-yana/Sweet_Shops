using sweetshops.Data;
using sweetshops.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace sweetshops.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _context.AuthUsers.FirstOrDefaultAsync(u => u.Email == Input.Email);

            if (user == null || user.Password != Input.Password)
            {
                ModelState.AddModelError(string.Empty, "Неверный логин или пароль.");
                return Page();
            }

            await Authenticate(user.Email, user.Role);
            return RedirectToPage("/Index");
        }

        private async Task Authenticate(string userName, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };

            // ИСПРАВЛЕНО: правильное создание ClaimsIdentity
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}