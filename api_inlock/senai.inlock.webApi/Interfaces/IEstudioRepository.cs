using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        //apenas Administrador pode cadastrar
        void Cadastrar(EstudioDomain Estudio);

        //Todos podem listar (Cliente e Administrador)
        List<EstudioDomain> ListarTodos();
    }
}
