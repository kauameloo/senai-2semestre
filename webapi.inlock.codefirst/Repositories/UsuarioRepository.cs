using webapi.inlock.codefirst.Contexts;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Utils;

namespace webapi.inlock.codefirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext ctx;
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
                
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Login(string Email, string Senha)
        {
            try
            {
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == Email);

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
