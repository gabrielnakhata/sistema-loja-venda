﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Entidades
{
    public class GraficoViewModel
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public double TotalVendido { get; set; }

    }
}
