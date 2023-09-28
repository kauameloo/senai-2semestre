﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "CPF obrigatório!")]
        public string CPF { get; set; }


        [Column(TypeName = "VARCHAR(3)")]
        [Required(ErrorMessage = "Idade obrigatória!")]
        public int? Idade { get; set; }

        [Required(ErrorMessage = "Id do Usuario obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
