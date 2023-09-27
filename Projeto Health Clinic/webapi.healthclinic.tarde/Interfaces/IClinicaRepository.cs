using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        List<Clinica> Listar();

        Clinica BuscarPorId(Guid id);

        void Atualizar(Guid id, Clinica clinica);
    }
}
