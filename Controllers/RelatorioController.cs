using Microsoft.AspNetCore.Mvc;
using sistema_loja_venda.Controllers.DAL;
using sistema_loja_venda.Entidades;
using System;
using System.Linq;

namespace sistema_loja_venda.Controllers
{
    public class RelatorioController : Controller
    {   
        protected ApplicationDbContext mContext;
        public RelatorioController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Grafico()
        {
            var lista = mContext.Venda_Produtos
                .GroupBy(x => x.Codigo_produto)
                .Select(y => new GraficoViewModel
                {
                    Codigoproduto = y.First().Codigo_produto,
                    Descricao = y.First().Produto.Descricao,
                    Totalvendido = y.Sum(z => z.Quantidade)
                }).ToList();

            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            var random = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].Totalvendido.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + ",";
                cores += "' " + String.Format("#{0:X6}", random.Next(i, i * 2)) + "',";
            }

            ViewBag["valores"] = valores;
            ViewBag["labels"] = labels;
            ViewBag["cores"] = cores; 
            
            return View();
        }
    }
}
