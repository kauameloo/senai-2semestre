using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "INT")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O CRM deve conter 6 caracteres")]
        [Required(ErrorMessage = "CRM obrigatório!")]
        public int? CRM { get; set; }

        [Required(ErrorMessage = "Id do Usuario obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Especialidade obrigatória!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

    }
}
