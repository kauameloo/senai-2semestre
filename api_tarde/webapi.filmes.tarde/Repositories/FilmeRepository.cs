using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
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
        private string? stringConexao = "Data Source = NOTE19-S15; Initial Catalog = FilmesTarde; User Id = sa; pwd = Senai@134";


        public void AtualizarIdCorpo(FilmeDomain Filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Filme SET Titulo = @TituloInserir, IdGenero = @GeneroInserir WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@TituloInserir", Filme.Titulo);
                    cmd.Parameters.AddWithValue("@GeneroInserir", Filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", Filme.IdFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdURL(int Id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Filme SET Titulo = @TituloInserir, IdGenero = @GeneroInserir WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@TituloInserir", filme.Titulo);
                    cmd.Parameters.AddWithValue("@GeneroInserir", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", Id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int Id)
        {
            FilmeDomain filmeEncontrado = new FilmeDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectFilme = "SELECT IdFilme, IdGenero, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectFilme, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", Id);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            filmeEncontrado = new FilmeDomain()
                            {
                                IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Titulo = rdr["Titulo"].ToString()
                            };
                        }
                    }
                }
            }
            return filmeEncontrado;
        }

        public void Cadastrar(FilmeDomain Filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "insert into Filme(IdGenero,Titulo) values(@IdGenero, @Titulo) ";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", Filme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", Filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryDelete = $"Delete from filme where IdFilme = {Id}";

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectFilme = "select IdFilme,IdGenero,Titulo from Filme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelectFilme, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            IdGenero = Convert.ToInt32(rdr[1]),

                            Titulo = rdr["Titulo"].ToString(),
                        };

                        ListaFilme.Add(filme);
                    };
                }
            }
            return ListaFilme;
        }
    }
}
