using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do estudio é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome pode ter no minimo 2 e no máximo 100 caracteres")]
        public string? Nome { get; set; }
    }
}
