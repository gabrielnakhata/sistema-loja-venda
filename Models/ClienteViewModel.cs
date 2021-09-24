using System.ComponentModel.DataAnnotations;

namespace sistema_loja_venda.Models
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage="Informe o nome do cliente!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ/CPF do cliente!")]
        public string CNPJ_CPF { get; set; }

        [Required(ErrorMessage = "Informe o E-mail do cliente!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o celular do cliente!")]
        public string Celular { get; set; }
    }
}
