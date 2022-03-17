using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp.Entities
{
    public class Promocao : BaseEntity
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public IList<PromocaoProduto> Produtos { get; set; }

        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }

        public void IncluiProduto(Produto produto)
        {
            this.Produtos.Add(new PromocaoProduto() { Produto = produto });
        }
    }
}
