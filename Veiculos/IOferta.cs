namespace ApiGraphQL.Veiculos
{
    [InterfaceType]

    public interface IOferta
    {
        int Id { get; }
        Veiculo Veiculo { get; }
        float Valor { get; }

    }
}