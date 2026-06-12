using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vendinha.Models
{
    public class Divida
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public decimal Valor { get; set; }
        public bool Paga { get; set; } = false;
        public DateTime DataCriacao { get; set; } 
        public DateTime? DataPagamento { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }

}

