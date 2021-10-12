using Microsoft.AspNetCore.Mvc;
using Aplicacao.Servico.Interfaces;
using sistema_loja_venda.Models;

namespace sistema_loja_venda.Controllers
{
    public class ClienteController : Controller
    {
       
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente) // O objeto ApplicationDbContext está sendo injetado no construtor da classe CategoriaController...
        {
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }
        public IActionResult Index()
        {
            return View(ServicoAplicacaoCliente.Listagem());
        }

        [HttpGet] // Atributo, decora uma função, procedimento ou classe determinando seu comportamento...
        public IActionResult Cadastro(int? id) // O operador "?", indica que a avariável é anulável, ou seja, pode receber valor "null".
        {
            ClienteViewModel viewModel = new ClienteViewModel();

            if (id != null)
            {
                viewModel = ServicoAplicacaoCliente.CarregarRegistro((int)id);
            }
            return View(viewModel);
        }

        [HttpPost] // 
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoCliente.Cadastrar(entidade);
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoCliente.Excluir(id);
            return RedirectToAction("Index");
        }
    }   
}
