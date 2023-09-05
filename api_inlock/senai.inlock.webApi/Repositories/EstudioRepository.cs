using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// STRING DE CONEXAO COM O BANCO DE DADOS QUE RECEBEM OS SEGUINTES PARÂMETROS
        /// DATA SOURCE = nome do servidor;
        /// INITIAL CATALOG = Nome do banco de dados;
        /// AUTENTIFICAÇÃO:
        ///     - WINDOWS =  Integrated Secutiry = True;
        ///     - SQLSERVER = User Id = sa; Senha = Senha;
        /// </summary>
        /// 
        private string? stringConexao = "Data Source = NOTE19-S15; Initial Catalog = inlock_games_tarde; User Id = sa; pwd = Senai@134";

        public void Cadastrar(EstudioDomain Estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES(@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {
                    cmd.Parameters.AddWithValue("@Nome", Estudio.Nome);

                    con.Open();

                    cmd.ExecuteReader();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> ListaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT IdEstudio, Nome from Estudio";

                con.Open ();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) 
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read()) 
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                        };

                        ListaEstudio.Add(estudio);
                    };
                }
            }
            return ListaEstudio;
        }
    }
}
