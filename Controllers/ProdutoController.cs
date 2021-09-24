using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        protected ApplicationDbContext mContext;

        public ProdutoController(ApplicationDbContext context) // O objeto ApplicationDbContext está sendo injetado no construtor da classe CategoriaController...
        {
            mContext = context; 
        }
        public IActionResult Index()
        {
            IEnumerable<Produto> lista = mContext.Produto.Include(x => x.Categoria).ToList();
            mContext.Dispose(); // Dispose limpar da memória...
            return View(lista);
        }
        private IEnumerable<SelectListItem> ListaCategorias()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Categoria.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }

            return lista;
        }

        [HttpGet] // Atributo, decora uma função, procedimento ou classe determinando seu comportamento...
        public IActionResult Cadastro(int? id) // O operador "?", indica que a avariável é anulável, ou seja, pode receber valor "null".
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();
            viewModel.ListaCategorias = ListaCategorias();

            if (id != null)
            {

                var entidade = mContext.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
                viewModel.Quantidade = entidade.Quantidade;
                viewModel.Valor = entidade.Valor;
                viewModel.Codigo_categoria = entidade.Codigo_categoria;
            }

            return View(viewModel);
        }

        [HttpPost] // Nesse contexto o atributo, tem como função determinar que esta rota da controller será chamada via post... 
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Produto objProduto = new Produto()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao,
                    Quantidade = entidade.Quantidade,
                    Valor = (decimal)entidade.Valor,
                    Codigo_categoria = entidade.Codigo_categoria
                };

                if (entidade.Codigo == null)
                {
                    mContext.Produto.Add(objProduto);
                }
                else
                {
                    mContext.Entry(objProduto).State = EntityState.Modified;
                }

                mContext.SaveChanges();
            }
            else
            {
                entidade.ListaCategorias = ListaCategorias();

                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Excluir(int id)
        {
            var ent = new Produto() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }   
}
