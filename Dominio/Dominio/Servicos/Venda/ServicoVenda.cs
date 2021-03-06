using Dominio.Interfaces;
using Dominio.Repositorio;
using sistema_loja_venda.Dominio.DTO;
using sistema_loja_venda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoVenda : IServicoVenda
    {
        IRepositorioVenda RepositorioVenda;
        IRepositorioVenda_Produtos RepositorioVenda_Produtos;

        public ServicoVenda(
            IRepositorioVenda repositorioVenda,
            IRepositorioVenda_Produtos repositorioVenda_Produtos)
        {
            RepositorioVenda = repositorioVenda;
            RepositorioVenda_Produtos = repositorioVenda_Produtos;
        }
        public void Cadastrar(Venda venda)
        {
            RepositorioVenda.Create(venda);
        }

        public Venda CarregarRegistro(int id)
        {
            return RepositorioVenda.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioVenda.Delete(id);
        }

        public IEnumerable<Venda> Listagem()
        {
            return RepositorioVenda.Read();
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            return RepositorioVenda_Produtos.ListaGrafico();
        }
    }
}
