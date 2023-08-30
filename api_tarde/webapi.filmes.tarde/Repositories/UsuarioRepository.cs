using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string? stringConexao = "Data Source = NOTE19-S15; Initial Catalog = FilmesTarde; User Id = sa; pwd = Senai@134";

        public UsuarioDomain BuscarPorEmail(string email)
        {
            UsuarioDomain usuarioEncontrado = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectUsuario = "SELECT IdUsuario, Permissao, Email, Senha FROM Usuario WHERE Email = @Email";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectUsuario, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            usuarioEncontrado = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Email = rdr["Email"].ToString(),
                                Senha = rdr["Senha"].ToString(),
                                Permissao = rdr["Permissao"].ToString()
                            };
                        }
                    }
                }
            }

            return usuarioEncontrado;
        }

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain usuario = null;

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT IdUsuario, Permissao, Email, Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha";

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
                                Email = rdr["Email"].ToString(),
                                Senha = rdr["Senha"].ToString(),
                                Permissao = rdr["Permissao"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }
    }
}
