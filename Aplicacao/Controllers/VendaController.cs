using Microsoft.AspNetCore.Mvc;
using Aplicacao.Servico.Interfaces;
using sistema_loja_venda.Models;


namespace sistema_loja_venda.Controllers
{
    public class VendaController : Controller
    {
        readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;
        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;


        public VendaController(
            IServicoAplicacaoVenda servicoAplicacaoVenda,
            IServicoAplicacaoProduto servicoAplicacaoProduto,
            IServicoAplicacaoCliente servicoAplicacaoCliente) // O objeto ApplicationDbContext está sendo injetado no construtor da classe CategoriaController...
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }
        public IActionResult Index()
        {
            return View(ServicoAplicacaoVenda.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();

            if (id != null)
            {
                viewModel = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            viewModel.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ListaProdutosDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoVenda.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
                entidade.ListaProdutos = ServicoAplicacaoProduto.ListaProdutosDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoVenda.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return (decimal)ServicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;
        }
    }   

}
