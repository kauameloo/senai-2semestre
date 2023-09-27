using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext ctx;

        public PacienteRepository()
        {
            ctx = new HealthContext();
        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = ctx.Paciente.Find(id);

            if (paciente != null)
            {
                pacienteBuscado.Idade = paciente.Idade;
            }

            ctx.Paciente.Update(pacienteBuscado!);
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = ctx.Paciente
                    .Select(u => new Paciente
                    {
                        IdPaciente = u.IdPaciente,
                        CPF = u.CPF,
                        Idade = u.Idade,

                        Usuario = new Usuario
                        {
                            IdUsuario = u.IdUsuario,
                            Nome = u.Usuario.Nome
                        }
                    }).FirstOrDefault(u => u.IdPaciente == id)!;

                return pacienteBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                ctx.Paciente.Add(paciente);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Paciente pacienteBuscado = ctx.Paciente.Find(id);

            if (pacienteBuscado != null)
            {
                ctx.Paciente.Remove(pacienteBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Paciente.ToList();
        }
    }
}
