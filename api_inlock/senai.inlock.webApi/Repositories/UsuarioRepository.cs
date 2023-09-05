using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain usuario = null;

            using (SqlConnection con = new SqlConnection(stringConexao)) 
            {
                string querySelect = "SELECT IdUsuario, IdTipoUsuario, Email, Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) 
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader()) 
                    {
                        if (rdr.Read()) 
                        {
                            usuario = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Email = rdr["Email"].ToString(),
                                Senha = rdr["Senha"].ToString(), //PAREI POR AQUI
                            };
                        }
                    }
                }
            }
        }
    }
}
