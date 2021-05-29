using MEChallenge.Application.Commands.Pedido;
using MEChallenge.Application.Domain.Interfaces;
using MEChallenge.Application.Domain.Models;
using MEChallenge.Application.Queries.Status;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEChallenge.Test
{
    [TestClass]
    public class UnitTest1
    {
        #region Pedidos
        [TestMethod]
        public async Task GetPedidosTest()
        {
            var repository = new Mock<IPedidoRepository>();

            var t = await repository.Object.List();
        }

        [TestMethod]
        public async Task AddPedidosTest()
        {
            var repository = new Mock<IPedidoRepository>();

            var cmd = new PedidoAddCommand()
            {
                Itens = new List<ItemMO> { new ItemMO() { Descricao = "Item A", PrecoUnitario = 21, Qtd = 2 } }
            };

            await repository.Object.Add(cmd);
        }

        [TestMethod]
        public async Task UpdatePedidoTest()
        {
            var repository = new Mock<IPedidoRepository>();

            var cmd = new PedidoUpdateCommand()
            {
                IdPedido = 123456,
                Itens = new List<ItemMO> { new ItemMO() { Descricao = "Item A", PrecoUnitario = 21, Qtd = 2 } }
            };

            await repository.Object.Update(cmd);
        }

        [TestMethod]
        public async Task DeletePedidoTest()
        {
            var repository = new Mock<IPedidoRepository>();

            var cmd = new PedidoDeleteCommand()
            {
                IdPedido = 123456
            };

            await repository.Object.Delete(cmd);
        }

        #endregion

        #region Status
        [TestMethod]
        public async Task GetStatus()
        {
            var repository = new Mock<IStatusRepository>();

            var qry = new StatusQuery()
            {
                ItensAprovados = 1,
                Pedido = "123456",
                Status = "APROVADO",
                ValorAprovado = 12
            };

            await repository.Object.GetStatus(qry);
        }
        #endregion
    }
}
