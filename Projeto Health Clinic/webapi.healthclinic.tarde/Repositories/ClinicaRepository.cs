using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext ctx;

        public ClinicaRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica clinicaBuscada = ctx.Clinica.Find(id);

            if (clinica != null)
            {
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.CNPJ = clinica.CNPJ;
                clinicaBuscada.Endereco = clinica.Endereco;
                clinicaBuscada.HoraAbertura = clinica.HoraAbertura;
                clinicaBuscada.HoraFechamento = clinica.HoraFechamento;
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
            }

            ctx.Clinica.Update(clinicaBuscada!);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = ctx.Clinica
                    .Select(u => new Clinica
                    {
                        IdClinica = u.IdClinica,
                        NomeFantasia = u.NomeFantasia,
                        CNPJ = u.CNPJ,
                        RazaoSocial = u.RazaoSocial,
                        HoraAbertura = u.HoraAbertura,
                        HoraFechamento = u.HoraFechamento,

                    }).FirstOrDefault(u => u.IdClinica == id)!;

                return clinicaBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                ctx.Clinica.Add(clinica);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Clinica clinicaBuscada = ctx.Clinica.Find(id);

            if (clinicaBuscada != null)
            {
                ctx.Clinica.Remove(clinicaBuscada);
            }

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinica.ToList();
        }
    }
}
