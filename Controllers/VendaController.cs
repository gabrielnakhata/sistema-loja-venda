using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_loja_venda.Controllers.DAL;
using sistema_loja_venda.Entidades;
using sistema_loja_venda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Controllers
{
    public class VendaController : Controller
    {
            protected ApplicationDbContext mContext;

            public VendaController(ApplicationDbContext context) // O objeto ApplicationDbContext está sendo injetado no construtor da classe CategoriaController...
            {
                mContext = context;
            }
            public IActionResult Index()
            {
                IEnumerable<Venda> lista = mContext.Venda.ToList();
                mContext.Dispose(); // Dispose limpar da memória...
                return View(lista);
            }
            private IEnumerable<SelectListItem> ListaProdutos()
            {
                List<SelectListItem> lista = new List<SelectListItem>();

                lista.Add(new SelectListItem()
                {
                    Value = string.Empty,
                    Text = string.Empty
                });

                foreach (var item in mContext.Produto.ToList())
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = item.Codigo.ToString(),
                        Text = item.Descricao.ToString()
                    });
                }

                return lista;
            }
            private IEnumerable<SelectListItem> ListaClientes()
            {
                List<SelectListItem> lista = new List<SelectListItem>();

                lista.Add(new SelectListItem()
                {
                    Value = string.Empty,
                    Text = string.Empty
                });

                foreach (var item in mContext.Cliente.ToList())
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = item.Codigo.ToString(),
                        Text = item.Nome.ToString()
                    });
                }

                return lista;
            }
        [HttpGet] // Atributo, decora uma função, procedimento ou classe determinando seu comportamento...
            public IActionResult Cadastro(int? id) // O operador "?", indica que a avariável é anulável, ou seja, pode receber valor "null".
            {
                VendaViewModel viewModel = new VendaViewModel();
                viewModel.ListaClientes = ListaClientes();
                viewModel.ListaProdutos = ListaProdutos();

            if (id != null)
                {

                    var entidade = mContext.Venda.Where(x => x.Codigo == id).FirstOrDefault();
                    viewModel.Codigo = entidade.Codigo;
                    viewModel.Data = entidade.Data;
                    viewModel.Codigo_cliente = entidade.Codigo_cliente;
                    viewModel.Total = entidade.Total;
                  
                }

                return View(viewModel);
            }

            [HttpPost] // Nesse contexto o atributo, tem como função determinar que esta rota da controller será chamada via post... 
            public IActionResult Cadastro(VendaViewModel entidade)
            {
                if (ModelState.IsValid)
                {
                    Venda objVenda = new Venda()
                    {
                        Codigo = entidade.Codigo,
                        Data = (DateTime)entidade.Data,
                        Codigo_cliente = (int)entidade.Codigo_cliente,
                        Total = entidade.Total,
                        Produtos = JsonConvert.DeserializeObject<ICollection<Venda_Produtos>>(entidade.JsonProdutos)
                    };

                    if (entidade.Codigo == null)
                    {
                        mContext.Venda.Add(objVenda);
                    }
                    else
                    {
                        mContext.Entry(objVenda).State = EntityState.Modified;
                    }

                    mContext.SaveChanges();
                }
                else
                {
                    entidade.ListaClientes = ListaClientes();
                    entidade.ListaProdutos = ListaProdutos();

                return View(entidade);
                }

                return RedirectToAction("Index");
            }

            [HttpGet]

            public IActionResult Excluir(int id)
            {
                var ent = new Venda() { Codigo = id };
                mContext.Attach(ent);
                mContext.Remove(ent);
                mContext.SaveChanges();
                return RedirectToAction("Index");
            }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return mContext.Produto.Where(x => x.Codigo == CodigoProduto).Select(x => x.Valor).FirstOrDefault();
        }
    }
}
