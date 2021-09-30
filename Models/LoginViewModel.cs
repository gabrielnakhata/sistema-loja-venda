using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage="Informe o E-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha!")]
        public string Senha { get; set; }
    }
}
