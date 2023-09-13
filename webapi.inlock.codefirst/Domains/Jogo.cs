using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Descrição obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data obrigatória!")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "Preço obrigatório!")]
        public decimal Preco { get; set; }

        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
    }
}
