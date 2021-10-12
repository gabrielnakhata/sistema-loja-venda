using Microsoft.AspNetCore.Mvc;

namespace sistema_loja_venda.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
