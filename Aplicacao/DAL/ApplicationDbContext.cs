using Microsoft.EntityFrameworkCore;
using sistema_loja_venda.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_loja_venda.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Venda_Produtos> Venda_Produtos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        // Essa classe está usuando a biblioteca do EntityFrameWork, e tem como
        // objetivo mapear as entidades para realizar as operações do sistema...
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Definindo Configurações para Classe "Venda_Produtos", herdeira da relação,
            // N/N entre as classes "Venda" e "Produto"...

            builder.Entity<Venda_Produtos>()
                .HasKey(x => new { x.Codigo_venda, x.Codigo_produto }); // Definindo a chave Primmária "PK" dupla.

            builder.Entity<Venda_Produtos>()
                .HasOne(x => x.Venda)   // tem uma...
                .WithMany(y => y.Produtos)   // com muitos...
                .HasForeignKey(x => x.Codigo_venda);   // possui a "FK"...

            builder.Entity<Venda_Produtos>()
                .HasOne(x => x.Produto)
                .WithMany(y => y.Vendas)
                .HasForeignKey(x => x.Codigo_produto);

        }
    }
}
