﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pokenae_WebApp.Data;
using pokenae_WebApp.Models;

namespace pokenae_WebApp.Pages.C_PokemonSoft
{
    public class DetailsModel : PageModel
    {
        private readonly pokenae_WebApp.Data.pokenae_WebAppContext _context;

        public DetailsModel(pokenae_WebApp.Data.pokenae_WebAppContext context)
        {
            _context = context;
        }

        public V_C_PokemonSoft V_C_PokemonSoft { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var v_c_pokemonsoft = await _context.V_C_PokemonSoft.FirstOrDefaultAsync(m => m.ID == id);
            if (v_c_pokemonsoft == null)
            {
                return NotFound();
            }
            else
            {
                V_C_PokemonSoft = v_c_pokemonsoft;
            }
            return Page();
        }
    }
}