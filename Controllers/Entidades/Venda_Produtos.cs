using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Entidades
{
    public class Venda_Produtos
    {
        public int Codigo_venda { get; set; }
        public int Codigo_produto { get; set; }
        public double Quantidade { get; set; }
        public decimal Valor_unitario { get; set; }
        public decimal Valor_total { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }

    }
}
