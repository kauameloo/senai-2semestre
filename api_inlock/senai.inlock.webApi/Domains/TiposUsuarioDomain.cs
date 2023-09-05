using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class TiposUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O titulo do tipo de usuário é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O titulo pode ter no minimo 2 e no máximo 100 caracteres")]
        public string? Titulo { get; set; }
    }
}
