using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        void Deletar(Guid id);

        List<Usuario> Listar();

        Usuario Login(string email, string senha);

        Usuario BuscarPorId(Guid id);

        void Atualizar(Guid id, Usuario usuario);
    }
}
