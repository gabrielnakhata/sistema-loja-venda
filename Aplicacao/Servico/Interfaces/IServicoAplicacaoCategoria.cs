using Microsoft.AspNetCore.Mvc.Rendering;
using sistema_loja_venda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<SelectListItem> ListaCategoriasDropDownList();
        IEnumerable<CategoriaViewModel> Listagem();
        CategoriaViewModel CarregarRegistro(int codigoCategoria);
        void Cadastrar(CategoriaViewModel categoria);
        void Excluir(int id);

    }
}
