using System;

namespace Alura.Loja.Testes.ConsoleApp.Entities
{
    public class PromocaoProduto
    {
        public Produto Produto { get; set; }
        public Promocao Promocao { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid PromocaoId { get; set; }
    }
}
