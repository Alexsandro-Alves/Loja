using Alura.Loja.Testes.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                /*var cliente = contexto
                    .Clientes
                    .Include(e => e.EnderecoDeEntrega)
                    .FirstOrDefault();*/

                /*Console.WriteLine(cliente.EnderecoDeEntrega.Cidade);*/

                var produto = contexto
                    .Produtos
                    .Include(p => p.Compras)
                    .Where(p => p.Id == new Guid("ec4124b4-9e20-4fb4-957c-08da06e8ed9d"))
                    .FirstOrDefault();

                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item.Quantidade);
                }

                contexto.SaveChanges();
            }
        }
        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
    }
}
