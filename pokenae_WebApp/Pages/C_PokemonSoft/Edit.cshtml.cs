using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pokenae_WebApp.Data;
using pokenae_WebApp.Models;

namespace pokenae_WebApp.Pages.C_PokemonSoft
{
    public class EditModel : PageModel
    {
        private readonly pokenae_WebApp.Data.pokenae_WebAppContext _context;

        public EditModel(pokenae_WebApp.Data.pokenae_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public V_C_PokemonSoft V_C_PokemonSoft { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var v_c_pokemonsoft =  await _context.V_C_PokemonSoft.FirstOrDefaultAsync(m => m.ID == id);
            if (v_c_pokemonsoft == null)
            {
                return NotFound();
            }
            V_C_PokemonSoft = v_c_pokemonsoft;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(V_C_PokemonSoft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!V_C_PokemonSoftExists(V_C_PokemonSoft.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool V_C_PokemonSoftExists(string id)
        {
            return _context.V_C_PokemonSoft.Any(e => e.ID == id);
        }
    }
}
