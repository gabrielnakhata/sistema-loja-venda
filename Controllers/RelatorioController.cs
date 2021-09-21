using Microsoft.AspNetCore.Mvc;
using sistema_loja_venda.Controllers.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }
    }
}
