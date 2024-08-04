using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pokenae_WebApp.Models;

namespace pokenae_WebApp.Data
{
    public class pokenae_WebAppContext : DbContext
    {
        public pokenae_WebAppContext (DbContextOptions<pokenae_WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<pokenae_WebApp.Models.M_Developer> M_Developer { get; set; } = default!;
        
        public DbSet<pokenae_WebApp.Models.V_M_PokemonSoft> V_M_PokemonSoft { get; set; } = default!;
        public DbSet<pokenae_WebApp.Models.V_M_Hard> V_M_Hard { get; set; } = default!;


        public DbSet<pokenae_WebApp.Models.C_PokemonSoft> C_PokemonSoft { get; set; } = default!;
        //public DbSet<pokenae_WebApp.Models.C_PokemonSoft_Hard> C_PokemonSoft_Hard { get; set; } = default!;
        //public DbSet<pokenae_WebApp.Models.C_PokemonSoft_Account> C_PokemonSoft_Account { get; set; } = default!;


        public DbSet<pokenae_WebApp.Models.V_C_PokemonSoft> V_C_PokemonSoft { get; set; } = default!;
        //public DbSet<pokenae_WebApp.Models.V_C_PokemonSoft> V_C_PokemonSoft_Package { get; set; } = default!;
        //public DbSet<pokenae_WebApp.Models.V_C_PokemonSoft_Hard> V_C_PokemonSoft_Hard { get; set; } = default!;
        //public DbSet<pokenae_WebApp.Models.V_C_PokemonSoft_Account> V_C_PokemonSoft_Account { get; set; } = default!;
    }
}
