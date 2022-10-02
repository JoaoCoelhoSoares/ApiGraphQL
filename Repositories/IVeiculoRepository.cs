using ApiGraphQL.Veiculos;

namespace ApiGraphQL.Repositories
{
    public interface IVeiculoRepository
    {
        // IVeiculo GetVeiculo(int id);
        IEnumerable<IVeiculo> GetVeiculos();

        void AddVeiculo(Veiculo veiculo);
    }
}