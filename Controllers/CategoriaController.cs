using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema_loja_venda.Controllers.DAL;
using sistema_loja_venda.Entidades;
using sistema_loja_venda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Controllers
{
    public class CategoriaController : Controller
    {
        protected ApplicationDbContext mContext;

        public CategoriaController(ApplicationDbContext context) // O objeto ApplicationDbContext está sendo injetado no construtor da classe CategoriaController...
        {
            mContext = context; 
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            mContext.Dispose();
            return View(lista);
        }

        [HttpGet] // Atributo, decora uma função, procedimento ou classe determinando seu comportamento...
        public IActionResult Cadastro(int? id) // O operador "?", indica que a avariável é anulável, ou seja, pode receber valor "null".
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();

            if (id != null)
            {

                var entidade = mContext.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
            }

            return View(viewModel);
        }

        [HttpPost] // 
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Categoria objCategoria = new Categoria()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao
                };

                if (entidade.Codigo == null)
                {
                    mContext.Categoria.Add(objCategoria);
                }
                else
                {
                    mContext.Entry(objCategoria).State = EntityState.Modified;
                }

                mContext.SaveChanges();
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
            var ent = new Categoria() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }   
}
