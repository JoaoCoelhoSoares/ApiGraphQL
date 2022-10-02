using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using ApiGraphQL.Repositories;

namespace ApiGraphQL.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class LeilaoSubscription
    {
        [Subscribe]
        public Veiculo OnLeilao([EventMessage] Veiculo message) => message;
    }
}