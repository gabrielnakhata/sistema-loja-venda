using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using sistema_loja_venda.Dominio.Entidades;

namespace Repositorio.Entidades
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
       public RepositorioUsuario(ApplicationDbContext dbContext) : base(dbContext) {
       }

        public bool ValidarLogin(string email, string senha)
        {
            var usuario = DbSetContext.Where(x => x.Email == email && x.Senha.ToUpper() == senha.ToUpper()).FirstOrDefault();
            return (usuario == null) ? false : true;
        }
    }
}
