using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome pode ter no minimo 2 e no máximo 100 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "A senha precisa de no minimo 10 e no máximo 100 caracteres")]
        public string? Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public int Valor { get; set; }

    }
}
