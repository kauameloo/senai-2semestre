using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext ctx;

        public ConsultaRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            if (consulta != null)
            {
                consultaBuscada.DataConsulta = consulta.DataConsulta;
                consultaBuscada.HoraConsulta = consulta.HoraConsulta;
                consultaBuscada.Prontuario = consulta.Prontuario;
                consultaBuscada.IdMedico = consulta.IdMedico;
            }

            ctx.Consulta.Update(consultaBuscada!);
            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                Consulta consultaBuscada = ctx.Consulta
                    .Select(u => new Consulta
                    {
                        IdConsulta = u.IdConsulta,
                        DataConsulta = u.DataConsulta,
                        HoraConsulta = u.HoraConsulta,
                        Prontuario = u.Prontuario,

                        Medico = new Medico
                        {
                            IdMedico = u.IdMedico,
                        },
                        Paciente = new Paciente
                        {
                            IdPaciente = u.IdPaciente,
                        }
                    }).FirstOrDefault(u => u.IdConsulta == id)!;

                return consultaBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                ctx.Consulta.Add(consulta);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            if (consultaBuscada != null)
            {
                ctx.Consulta.Remove(consultaBuscada);
            }

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta.ToList();
        }
    }
}
