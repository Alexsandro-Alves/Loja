using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Alura.Loja.Testes.ConsoleApp;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    [DbContext(typeof(LojaContext))]
    [Migration("20220317171001_Add_Table_Cliente")]
    partial class Add_Table_Cliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Nome");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Compra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<double>("Preco");

                    b.Property<Guid>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Entities.Endereco", b =>
                {
                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<string>("Logradouro");

                    b.Property<int>("Numero");

                    b.HasKey("ClienteId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Entities.Promocao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DataFinal");

                    b.Property<DateTime>("DataInicio");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Descricao");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Entities.PromocaoProduto", b =>
                {
                    b.Property<Guid>("ProdutoId");

                    b.Property<Guid>("PromocaoId");

                    b.HasKey("ProdutoId", "PromocaoId");

                    b.HasIndex("PromocaoId");

                    b.ToTable("PromocaoProduto");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categoria");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Nome");

                    b.Property<double>("PrecoUnitario");

                    b.Property<string>("Unidade");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Compra", b =>
                {
                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Entities.Endereco", b =>
                {
                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Cliente", "Cliente")
                        .WithOne("EnderecoDeEntrega")
                        .HasForeignKey("Alura.Loja.Testes.ConsoleApp.Entities.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Entities.PromocaoProduto", b =>
                {
                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Produto", "Produto")
                        .WithMany("Promocoes")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Entities.Promocao", "Promocao")
                        .WithMany("Produtos")
                        .HasForeignKey("PromocaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
