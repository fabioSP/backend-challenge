namespace MEChallenge.Application.Domain.Entities
{
    public class ProdutoMO
    {
        public ProdutoMO(int id, string descricao, double precoUnitario)
        {
            Id = id;
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public double PrecoUnitario { get; private set; }
    }
}
