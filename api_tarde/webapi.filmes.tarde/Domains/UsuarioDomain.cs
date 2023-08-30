using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatoria")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A permissão é obrigatoria")]
        public string Permissao { get; set; }

    }
}
