using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext ctx;

        public MedicoRepository()
        {
            ctx = new HealthContext();
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medicoBuscado = ctx.Medico
                    .Select(u => new Medico
                    {
                        IdMedico = u.IdMedico,
                        CRM = u.CRM,

                        Usuario = new Usuario
                        {
                            IdUsuario = u.IdUsuario,
                            Nome = u.Usuario.Nome
                        },
                        Especialidade = new Especialidade
                        {
                            IdEspecialidade = u.IdEspecialidade,
                            Titulo = u.Especialidade.Titulo
                        },
                    }).FirstOrDefault(u => u.IdMedico == id)!;

                return medicoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                ctx.Medico.Add(medico);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Medico medicoBuscado = ctx.Medico.Find(id);

            if (medicoBuscado != null)
            {
                ctx.Medico.Remove(medicoBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medico.ToList();
        }
    }
}
