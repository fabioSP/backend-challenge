using MEChallenge.Application.Domain.Entities;
using MEChallenge.Application.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MEChallenge.Application.Shared
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var prod1 = new ProdutoMO(1, "Item A", 10);
            var prod2 = new ProdutoMO(2, "Item B", 5);

            using var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());
            context.Produto.Add(prod1);
            context.Produto.Add(prod2);

            var pedido1 = new PedidoMO(123456, 1, 1);
            var pedido2 = new PedidoMO(123456, 2, 2);

            context.Pedido.Add(pedido1);
            context.Pedido.Add(pedido2);

            context.SaveChanges();
        }
    }
}
