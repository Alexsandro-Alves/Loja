using Alura.Loja.Testes.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(x => new { x.ProdutoId, x.PromocaoId });
            base.OnModelCreating(modelBuilder);

            /*Altera o nome da tabela Endereco para Enderecos*/
            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");

            /*Cria uma nova propriedade na tabela Endereco*/
            modelBuilder
                .Entity<Endereco>()
                .Property<Guid>("ClienteId");

            /*Diz que a primary key da tabela Enderecos é ClienteId*/
            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }
    }
}