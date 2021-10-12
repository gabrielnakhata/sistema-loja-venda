using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace sistema_loja_venda.Controllers
{
    public class RelatorioController : Controller
    {
        readonly IServicoAplicacaoVenda ServicoVenda;
        public RelatorioController(IServicoAplicacaoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
        }

        public IActionResult Grafico()
        {
            var lista = ServicoVenda.ListaGrafico().ToList();
            
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
