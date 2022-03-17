using Alura.Loja.Testes.ConsoleApp.Entities;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Compra : BaseEntity
    {
        public int Quantidade { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public double Preco { get; set; } 
    }
}