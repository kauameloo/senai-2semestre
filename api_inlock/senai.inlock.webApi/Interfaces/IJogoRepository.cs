using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {
        //apenas Administrador pode cadastrar
        void Cadastrar(JogoDomain Jogo);

        //Todos podem listar (Cliente e Administrador)
        List<JogoDomain> ListarTodos();

    }
}
