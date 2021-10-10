using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IServicoCRUD<TEntidade>
        where TEntidade: class
    {
        IEnumerable<TEntidade> Listagem();
        void Cadastrar(TEntidade categoria);
        TEntidade CarregarRegistro(int id);
        void Excluir(int id);
    }
}
