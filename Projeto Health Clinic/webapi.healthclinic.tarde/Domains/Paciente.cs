using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "INT")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        [Required(ErrorMessage = "CPF obrigatório!")]
        public int? CPF { get; set; }


        [Column(TypeName = "VARCHAR(3)")]
        [Required(ErrorMessage = "Idade obrigatória!")]
        public int? Idade { get; set; }

        [Required(ErrorMessage = "Id do Usuario obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
