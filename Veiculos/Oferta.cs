namespace ApiGraphQL.Veiculos
{
    public class Oferta : IOferta
    {
        public Oferta(int id, Veiculo veiculo, float valor)
        {
            Id = id;
            Veiculo = veiculo;
            Valor = valor;
        }

        public int Id { get; }
        public Veiculo Veiculo { get; }
        public float Valor { get; }
    }
}