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
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
       public RepositorioVenda(ApplicationDbContext dbContext) : base(dbContext) {
       }
        public override void Delete(int id)
        {
            //Antes precisamos excluir os id's de venda que estão na tabela Venda_Produtos...

            var listaprodutos = DbSetContext.
                Include(x => x.Produtos).
                Where(y => y.Codigo == id).
                AsNoTracking().
                ToList();

            Venda_Produtos vendaProdutos;
            foreach (var item in listaprodutos[0].Produtos)
            {
                vendaProdutos = new Venda_Produtos();
                vendaProdutos.Codigo_venda = id;
                vendaProdutos.Codigo_produto = item.Codigo_produto;
                
                //Delete dos produtos da
                DbSet<Venda_Produtos> DbSetAux;
                DbSetAux = Db.Set<Venda_Produtos>();
                DbSetAux.Attach(vendaProdutos);
                DbSetAux.Remove(vendaProdutos);
                Db.SaveChanges();
            }
            //Delete da venda
            base.Delete(id);
        }
    }
}
