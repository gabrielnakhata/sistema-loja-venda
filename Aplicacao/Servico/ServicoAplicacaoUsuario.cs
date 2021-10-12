
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
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private readonly IServicoUsuario ServicoUsuario;

        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
        {
            ServicoUsuario = servicoUsuario;      
        }

        public Usuario RetornarDadosUsuario(string email, string senha)
        {
            return ServicoUsuario.Listagem().Where(x => x.Email == email && x.Senha.ToUpper() == senha.ToUpper()).FirstOrDefault();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return ServicoUsuario.ValidarLogin(email, senha);
        }

    }
}
