using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
namespace ApiGraphQL.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class OfertaSubscription
    {
        [Subscribe]
        public Oferta OfertaMaior([EventMessage] Oferta message) => message;
    }
}