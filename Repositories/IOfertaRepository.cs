using ApiGraphQL.Veiculos;

namespace ApiGraphQL.Repositories
{
    public interface IOfertaRepository
    {
        // IVeiculo GetVeiculo(int id);
        void AddOferta(Oferta oferta);

        Oferta MaiorOferta();

        IEnumerable<IOferta> CreateOferta();

        Dictionary<int, IOferta> GetAll();
    }
}