using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Alura.Loja.Testes.ConsoleApp;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    [DbContext(typeof(LojaContext))]
    [Migration("20220316003813_Migration_Inicial")]
    partial class Migration_Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<Guid>("Id");

                    b.Property<DateTime>("UpdatedAt");

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
