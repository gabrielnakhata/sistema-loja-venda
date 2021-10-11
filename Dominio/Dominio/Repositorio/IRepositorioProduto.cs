using sistema_loja_venda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorioProduto : IRepositorio<Produto>
    {
        new IEnumerable<Produto> Read(); // IRepositorioProduto VOCÊ é obrigado a reimplementar este método!
                                         // mesmo HERDANDO é obrigado a gerar um novo, "new"...
    }
}
