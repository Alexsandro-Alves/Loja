using Alura.Loja.Testes.ConsoleApp.Entities;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double PrecoUnitario { get; set; }
        public string Unidade { get; set;  }
        public IList<PromocaoProduto> Promocoes { get; set; }
        public IList<Compra> Compras { get; set; }

        public override string ToString()
        {
            return $"Produto: {this.Id}, {this.Nome}, {this.Categoria}, {this.PrecoUnitario}";
        }
    }
}