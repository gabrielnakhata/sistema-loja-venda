using Dominio.Interfaces;
using Dominio.Repositorio;
using sistema_loja_venda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        IRepositorioUsuario RepositorioUsuario;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }
        public void Cadastrar(Usuario usuario)
        {
            RepositorioUsuario.Create(usuario);
        }

        public Usuario CarregarRegistro(int id)
        {
            return RepositorioUsuario.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioUsuario.Delete(id);
        }

        public IEnumerable<Usuario> Listagem()
        {
            return RepositorioUsuario.Read();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return RepositorioUsuario.ValidarLogin(email, senha);
        }
    }
}
