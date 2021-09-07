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
    public class ClienteController : Controller
    {
        protected ApplicationDbContext mContext;

        public ClienteController(ApplicationDbContext context) // O objeto ApplicationDbContext está sendo injetado no construtor da classe CategoriaController...
        {
            mContext = context; 
        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = mContext.Cliente.ToList();
            mContext.Dispose(); // Dispose limpar da memória...
            return View(lista);
        }

        [HttpGet] // Atributo, decora uma função, procedimento ou classe determinando seu comportamento...
        public IActionResult Cadastro(int? id) // O operador "?", indica que a avariável é anulável, ou seja, pode receber valor "null".
        {
            ClienteViewModel viewModel = new ClienteViewModel();

            if (id != null)
            {

                var entidade = mContext.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Nome = entidade.Nome;
                viewModel.CNPJ_CPF = entidade.CNPJ_CPF;
                viewModel.Email = entidade.Email;
                viewModel.Celular = entidade.Celular;
            }

            return View(viewModel);
        }

        [HttpPost] // Nesse contexto o atributo, tem como função determinar que esta rota da controller será chamada via post... 
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Cliente objCliente = new Cliente()
                {
                    Codigo = entidade.Codigo,
                    Nome = entidade.Nome,
                    CNPJ_CPF = entidade.CNPJ_CPF,
                    Email = entidade.Email,
                    Celular = entidade.Celular
                };

                if (entidade.Codigo == null)
                {
                    mContext.Cliente.Add(objCliente);
                }
                else
                {
                    mContext.Entry(objCliente).State = EntityState.Modified;
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
            var ent = new Cliente() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }   
}
