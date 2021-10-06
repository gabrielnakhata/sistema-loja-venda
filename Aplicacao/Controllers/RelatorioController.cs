using Microsoft.AspNetCore.Mvc;
using sistema_loja_venda.DAL;
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
                .AsEnumerable()
                .GroupBy(x => x.Codigo_produto)
                .Select(y => new GraficoViewModel
                {
                    CodigoProduto = y.First().Codigo_produto,
                    Descricao = y.First().Produto.Descricao,
                    TotalVendido = y.Sum(z => z.Quantidade)
                }).ToList();
            
            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            var random = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendido.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }
            
            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores; 
            
            return View();
        }
    }
}
