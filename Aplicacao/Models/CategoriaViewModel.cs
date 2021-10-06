﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Models
{
    public class CategoriaViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage="Informe a descrição da categoria!")]
        public string Descricao { get; set; }
    }
}
