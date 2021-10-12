using sistema_loja_venda.Dominio.Entidades;
using sistema_loja_venda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda
    {
        IEnumerable<VendaViewModel> Listagem();
        VendaViewModel CarregarRegistro(int codigoVenda);
        void Cadastrar(VendaViewModel venda);
        void Excluir(int id);

    }
}
