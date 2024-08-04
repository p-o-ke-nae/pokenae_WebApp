using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pokenae_WebApp.Data;
using pokenae_WebApp.Models;

namespace pokenae_WebApp.Pages.C_PokemonSoft
{
    public class CreateModel : PageModel
    {
        private readonly pokenae_WebApp.Data.pokenae_WebAppContext _context;

        public CreateModel(pokenae_WebApp.Data.pokenae_WebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public V_C_PokemonSoft V_C_PokemonSoft { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.V_C_PokemonSoft.Add(V_C_PokemonSoft);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
