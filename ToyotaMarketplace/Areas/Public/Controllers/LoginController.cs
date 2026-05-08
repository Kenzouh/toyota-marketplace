using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.ViewModels.Public.Login;

namespace ToyotaMarketplace.Areas.Public.Controllers
{
    [Area("Public")]
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Login")]
        public IActionResult Index()
        {
            // If user is already authenticated, redirect based on role.
            if (User.Identity?.IsAuthenticated == true)
            {
                var role = User.FindFirst(ClaimTypes.Role)?.Value;

                if (role == "Admin")
                {
                    return RedirectToAction("ContactUs", "Home", new { area = "Public" });
                }
                else
                {
                    return RedirectToAction("Marketplace", "Home", new { area = "Public" });
                }
            }
            return View();
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ValidationFailed"] = "true";
                return View(model);
            }

            var user = await _context.Users
                .Include(u => u.ToyotaAdmin)
                .FirstOrDefaultAsync(u => u.Email == model.Email); 

            if (user == null || string.IsNullOrEmpty(user.Password) || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password."); // string.Empty = general model error
                return View(model); // Only clears PW but not email field when validation comes.
            }

            var role = user.ToyotaAdmin != null ? "Admin" : "User";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserFirstName ?? "User"),
                new Claim(ClaimTypes.Role, role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Remember login
                ExpiresUtc = DateTime.UtcNow.AddHours(2)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            if (role == "Admin")
                return RedirectToAction("ContactUs", "Home", new { area = "Public" });

            return RedirectToAction("Marketplace", "Home", new { area = "Public" });
        }

        [HttpPost("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Removes authentication Cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home", new { area = "Public" });
        }
    }
}
