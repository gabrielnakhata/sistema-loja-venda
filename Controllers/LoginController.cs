using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistema_loja_venda.DAL;
using sistema_loja_venda.Helpers;
using sistema_loja_venda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.Controllers
{
    public class LoginController : Controller
    {
        protected ApplicationDbContext mContext;
        protected IHttpContextAccessor HttpContextAcessor;

        public LoginController(ApplicationDbContext context,  IHttpContextAccessor httpContext)
        {
            mContext = context;
            HttpContextAcessor = httpContext;
        }
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContextAcessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty;

            if (ModelState.IsValid)
            {
               var senha = Criptografia.GetMd5Hash(model.Senha);
               var usuario = mContext.Usuario.Where(x => x.Email == model.Email && x.Senha == senha).FirstOrDefault();

               if (usuario == null)
               {
                    ViewData["ErroLogin"] = "O E-mail ou Senha informado não existe no sistema!";
                    return View(model);
               }
               else
               {
                    // Colocar os dados do usuário na sessão...
                    HttpContextAcessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    HttpContextAcessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    HttpContextAcessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    HttpContextAcessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);

                    return RedirectToAction("Index", "Home");
               }
            }
            else
            {
                return View(model);
            }
        }
    }
}
