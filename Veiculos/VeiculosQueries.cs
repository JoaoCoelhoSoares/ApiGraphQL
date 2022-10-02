using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using ApiGraphQL.Repositories;

namespace ApiGraphQL.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class VeiculosQueries
    {
        // public GetVeiculo(int id, [Service] VeiculoRepository repository) => repository.GetVeiculos(id);
        public IEnumerable<IVeiculo> GetVeiculos([Service] IVeiculoRepository repository) => repository.GetVeiculos();

        [GraphQLName("get_veiculo")]
        public Veiculo GetVeiculo(int? id)
        {
            var veiculo = new Veiculo(1, "Nome", "Dono", "Cor", 12120);
            return veiculo;
        }

    }
}