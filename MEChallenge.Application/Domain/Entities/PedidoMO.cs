using System.ComponentModel.DataAnnotations;

namespace MEChallenge.Application.Domain.Entities
{
    public class PedidoMO
    {
        public PedidoMO(int idProduto, int quantidade)
        {
            IdProduto = idProduto;
            Quantidade = quantidade;
        }

        public PedidoMO(int id, int idProduto, int quantidade)
        {
            Id = id;
            IdProduto = idProduto;
            Quantidade = quantidade;
        }

        [Key]
        public int Id { get; private set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
