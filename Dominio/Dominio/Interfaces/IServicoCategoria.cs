using sistema_loja_venda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IServicoCategoria
    {
        IEnumerable<Categoria> Listagem();
        void Cadastrar(Categoria categoria);
        Categoria CarregarRegistro(int id);
        void Excluir(int id);
    }
}
