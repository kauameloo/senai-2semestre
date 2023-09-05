using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatorio")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha precisa de no minimo 3 e no máximo 20 caracteres")]
        [Required(ErrorMessage = "A senha é obrigatoria")]
        public string Senha { get; set; }
    }
}
