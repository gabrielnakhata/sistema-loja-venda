using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using sistema_loja_venda.Dominio.DTO;
using sistema_loja_venda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class RepositorioVenda_Produtos : IRepositorioVenda_Produtos
    {
        protected ApplicationDbContext DbSetContext;

        public RepositorioVenda_Produtos(ApplicationDbContext mContext)
        {
            DbSetContext = mContext;
        }
        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            var lista = DbSetContext.Venda_Produtos.Include(x => x.Produto)
                      .AsEnumerable()
                      .GroupBy(x => x.Codigo_produto)
                      .Select(y => new GraficoViewModel
                      {
                         CodigoProduto = y.First().Codigo_produto,
                         Descricao = y.First().Produto.Descricao,
                         TotalVendido = y.Sum(z => z.Quantidade)

                      }).ToList();
            return lista;
        }
    }
}
