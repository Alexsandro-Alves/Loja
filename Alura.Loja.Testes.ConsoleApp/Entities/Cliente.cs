using Alura.Loja.Testes.ConsoleApp.Entities;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public Endereco EnderecoDeEntrega { get; set; }
    }
}