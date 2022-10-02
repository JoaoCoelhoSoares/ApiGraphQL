using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using ApiGraphQL.Repositories;

namespace ApiGraphQL.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class OfertasQueries
    {
        [GraphQLName("busca_ofertas")]
        public Dictionary<int, IOferta> GetOfertas([Service] IOfertaRepository repository)
        {
            return repository.GetAll();
        }

        // public GetVeiculo(int id, [Service] VeiculoRepository repository) => repository.GetVeiculos(id);
        /*  public IEnumerable<IVeiculo> GetOfertas([Service] IOfertaRepository repository) => repository.MaiorOferta();

         [GraphQLName("get_oferta")]
         public Oferta GetOferta(int? id)
         {
             var oferta = new Oferta(1, new Veiculo(1, "Nome", "Dono", "Cor", 12120), 12120);
             return oferta;
         } */

    }
}