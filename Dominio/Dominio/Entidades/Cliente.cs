using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Dominio.Entidades
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string CNPJ_CPF { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public ICollection<Venda> Vendas { get; set; }



    }
}
