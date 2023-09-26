using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Contexts
{
    public class HealthContext : DbContext
    {
        /// <summary>
        /// Definição das entidades do banco de dados
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Especialidade> Especialidade { get; set; }

        public DbSet<Consulta> Consulta { get; set; }

        public DbSet<Clinica> Clinica { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE19-S15; Database=healthclinic_api_tarde; User Id = sa; pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
