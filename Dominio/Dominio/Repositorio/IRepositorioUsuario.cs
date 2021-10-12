using sistema_loja_venda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        bool ValidarLogin(string email, string senha);
    }
}
