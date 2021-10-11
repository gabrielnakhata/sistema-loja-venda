using Microsoft.AspNetCore.Mvc;
using Aplicacao.Servico.Interfaces;
using Microsoft.EntityFrameworkCore;
using sistema_loja_venda.DAL;
using sistema_loja_venda.Entidades;
using sistema_loja_venda.Models;
using System.Collections.Generic;
using System.Linq;

namespace sistema_loja_venda.Controllers
{
    public class ProdutoController : Controller
    {
       
        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;


        public ProdutoController(
            IServicoAplicacaoProduto servicoAplicacaoProduto,
            IServicoAplicacaoCategoria servicoAplicacaoCategoria) // O objeto ApplicationDbContext está sendo injetado no construtor da classe CategoriaController...
        {
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }
        public IActionResult Index()
        {
            return View(ServicoAplicacaoProduto.Listagem());
        }

        [HttpGet] // Atributo, decora uma função, procedimento ou classe determinando seu comportamento...
        public IActionResult Cadastro(int? id) // O operador "?", indica que a avariável é anulável, ou seja, pode receber valor "null".
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();

            if (id != null)
            {
                viewModel = ServicoAplicacaoProduto.CarregarRegistro((int)id);
            }

            viewModel.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();

            return View(viewModel);
        }

        [HttpPost] // 
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoProduto.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoProduto.Excluir(id);
            return RedirectToAction("Index");
        }
    }   
}
