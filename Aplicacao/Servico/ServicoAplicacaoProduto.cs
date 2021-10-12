using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using sistema_loja_venda.Dominio.Entidades;
using sistema_loja_venda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto ServicoProduto;

        public ServicoAplicacaoProduto(IServicoProduto servicoProduto)
        {
            ServicoProduto = servicoProduto;      
        }
        public void Cadastrar(ProdutoViewModel produto)
        {
            Produto item = new Produto()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                Valor = (decimal)produto.Valor,
                Codigo_categoria = (int)produto.Codigo_categoria
            };

            ServicoProduto.Cadastrar(item);
        }
        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
            var registro = ServicoProduto.CarregarRegistro(codigoProduto);

            ProdutoViewModel produto = new ProdutoViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = (decimal)registro.Valor,
                Codigo_categoria = (int)registro.Codigo_categoria
            };

            return produto;
        }

        public void Excluir(int id)
        {
            ServicoProduto.Excluir(id);
        }
        public IEnumerable<SelectListItem> ListaProdutosDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem produto = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };
                retorno.Add(produto);
            }
            return retorno;
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = ServicoProduto.Listagem();
            List<ProdutoViewModel> listaProdutos = new List<ProdutoViewModel>();

            foreach (var item in lista)
            {
                ProdutoViewModel produto = new ProdutoViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    Quantidade = item.Quantidade,
                    Valor = (decimal)item.Valor,
                    Codigo_categoria = (int)item.Codigo_categoria,
                    DescricaoCategoria = item.Categoria.Descricao
                };
                listaProdutos.Add(produto);
            }

            return listaProdutos;
        }
    }
}
