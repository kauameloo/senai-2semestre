using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome Fantasia obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatório!")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereco obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Razão Social obrigatória!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horario de abertura obrigatória!")]
        public TimeSpan? HoraAbertura { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horario de fechamento obrigatório!")]
        public TimeSpan? HoraFechamento { get; set; }
    }
}
