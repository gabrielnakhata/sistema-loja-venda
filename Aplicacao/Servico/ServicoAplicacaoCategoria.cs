using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using sistema_loja_venda.Dominio.Entidades;
using sistema_loja_venda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria ServicoCategoria;

        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)
        {
            ServicoCategoria = servicoCategoria;      
        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {
            var registro = ServicoCategoria.CarregarRegistro(codigoCategoria);

            CategoriaViewModel categoria = new CategoriaViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao
            };

            return categoria;
        }

        public void Excluir(int id)
        {
            ServicoCategoria.Excluir(id);
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            Categoria item = new Categoria()
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            ServicoCategoria.Cadastrar(item);
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            var Lista = ServicoCategoria.Listagem();
            List<CategoriaViewModel> listaCategoria = new List<CategoriaViewModel>();

            foreach (var item in Lista)
            {
                CategoriaViewModel Categoria = new CategoriaViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };

                listaCategoria.Add(Categoria);
            }

            return listaCategoria;
        }
    }
}
