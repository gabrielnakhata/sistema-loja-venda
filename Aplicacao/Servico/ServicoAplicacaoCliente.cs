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
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente ServicoCliente;

        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            ServicoCliente = servicoCliente;      
        }
        public void Cadastrar(ClienteViewModel cliente)
        {
            Cliente item = new Cliente()
            {
                Codigo = cliente.Codigo,
                Nome = cliente.Nome,
                CNPJ_CPF = cliente.CNPJ_CPF,
                Celular = cliente.Celular,
                Email = cliente.Email
            };

            ServicoCliente.Cadastrar(item);
        }
        public ClienteViewModel CarregarRegistro(int codigoCliente)
        {
            var registro = ServicoCliente.CarregarRegistro(codigoCliente);

            ClienteViewModel cliente = new ClienteViewModel()
            {
                Codigo = registro.Codigo,
                Nome = registro.Nome,
                CNPJ_CPF = registro.CNPJ_CPF,
                Celular = registro.Celular,
                Email = registro.Email
            };

            return cliente;
        }

        public void Excluir(int id)
        {
            ServicoCliente.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaClientesDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem cliente = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                };
                retorno.Add(cliente);
            }
            return retorno;
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = ServicoCliente.Listagem();
            List<ClienteViewModel> listaCliente = new List<ClienteViewModel>();

            foreach (var item in lista)
            {
                ClienteViewModel cliente = new ClienteViewModel() // REFATORAR DEPOIS REPETIÇÕES...
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Celular = item.Celular,
                    Email = item.Email
                };
                listaCliente.Add(cliente);
            }

            return listaCliente;
        }
    }
}
