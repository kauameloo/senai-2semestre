using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        void Deletar(Guid id);

        List<Usuario> Listar();

        Usuario BuscarPorEmailESenha(string email, string senha);

        Usuario BuscarPorId(Guid id);

        void Atualizar(Guid id, Usuario usuario);
    }
}
