using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Entidades
{
    public class Venda
    {
        [Key]
        public int? Codigo { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("Cliente")]
        public int Codigo_Cliente { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }

    }
}
