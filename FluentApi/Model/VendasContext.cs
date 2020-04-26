using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Model
{
    public class VendasContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }

        public VendasContext() : base("name=VendasConnectionString")
        { 

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir um schema padrão para as tabelas
            modelBuilder.HasDefaultSchema("venda");

            // Alterar o nome das tabelas e o schema padrão
            // Definindo a propriedade Id como autoincremento
            modelBuilder.Entity<Cliente>()
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Produto>()
                .ToTable("ProdutosAVenda", "estoque")
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<VendaItem>()
                .ToTable("ItensDaVenda")
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Venda>()
                .ToTable("VendasRealizadas")
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Definindo os relacionamentos
            modelBuilder.Entity<Venda>()
                .HasRequired<Cliente>(v => v.Cliente).WithMany(c => c.ComprasRealizadas)
                .HasForeignKey(f => f.ClienteId);

            modelBuilder.Entity<VendaItem>()
                .HasRequired<Produto>(p => p.Produto).WithMany(p => p.VendaItens)
                .HasForeignKey(f => f.ProdutoId);

            modelBuilder.Entity<VendaItem>()
                .HasRequired<Venda>(p => p.Venda).WithMany(p => p.ItensDaVenda)
                .HasForeignKey(f => f.VendaId);
        }
    }
}
