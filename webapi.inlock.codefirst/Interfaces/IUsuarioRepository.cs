using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string Email, string Senha);

        void Cadastrar(Usuario usuario);
    }
}
