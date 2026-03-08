using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GRTAssist.Web.Pages
{
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                Response.Redirect("/Login");
            }
        }
    }
}