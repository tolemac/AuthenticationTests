using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CookieAuthenticationTest.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {            

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(
                        new List<Claim> {
                            new Claim(ClaimTypes.Name, "jros@jros.org"),
                            new Claim("FullName", "Javier Ros Moreno"),
                            new Claim(ClaimTypes.Role, "Admin"),
                            new Claim(ClaimTypes.Role, "User"),
                        }
                        , CookieAuthenticationDefaults.AuthenticationScheme
                    )), new AuthenticationProperties
                    {

                    }
                );

            return Page();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Page();
        }

    }
}