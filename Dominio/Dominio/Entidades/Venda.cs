
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Dominio.Entidades
{
    public class Venda : EntityBase
    {
        public DateTime Data { get; set; }

        [ForeignKey("Cliente")]
        public int Codigo_cliente { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public ICollection<Venda_Produtos> Produtos { get; set; }
    }
}
