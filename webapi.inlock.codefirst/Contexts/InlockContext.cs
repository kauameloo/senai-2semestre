﻿using Microsoft.EntityFrameworkCore;
using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Contexts
{
    public class InlockContext : DbContext
    {
        /// <summary>
        /// Definição das entidades do banco de dados
        /// </summary>
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE19-S15; Database=inlock_games_codeFirst_tarde; User Id = sa; pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
