using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sistema_loja_venda.Controllers.DAL;
using sistema_loja_venda.Entidades;
using sistema_loja_venda.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext Repositorio;

        public HomeController(ApplicationDbContext repositorio)
        {
            Repositorio = repositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
