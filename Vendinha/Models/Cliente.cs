using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendinha.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "O Nome é Obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O CPF é Obrigatório")]
        public DateTime DataNascimento { get; set; }
        [EmailAddress(ErrorMessage = "A data de nascimento é Obrigatória")]
        public string? Email { get; set; }

        public List<Divida> Dividas { get; set; } = new();
    }
}