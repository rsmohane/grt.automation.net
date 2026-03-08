using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GRTAssist.Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Simple demo login
            if (Username == "admin" && Password == "password")
            {
                // In real app, use SignInManager
                HttpContext.Session.SetString("User", Username);
                return RedirectToPage("/Admin");
            }
            else
            {
                ErrorMessage = "Invalid credentials";
                return Page();
            }
        }
    }
}