using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using pokenae_WebApp.Models;

namespace pokenae_WebApp.Pages.C_PokemonSoft
{
    public class ActionResultModel : PageModel
    {
        public IActionResult OnGet(string id)
        {
            var item = new C_Account_Switch() { ID = "ae" + id, Name = "aespa" };
            return Content(item.ToJson(), "application/json");
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPostAsync(C_Account_Switch cas)
        {
            var item = new C_Account_Switch() { ID = "ae" + cas.ID,Name = cas.Name };
            return Content(item.ToJson(), "application/json");
        }

    }
}
