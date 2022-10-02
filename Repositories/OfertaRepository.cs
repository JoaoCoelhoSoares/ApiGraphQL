using System.Linq;
using ApiGraphQL.Veiculos;

namespace ApiGraphQL.Repositories
{
    public class OfertaRepository //: IVeiculoRepository
    {
        private Dictionary<int, IOferta> _ofertas;

        public OfertaRepository()
        {
            _ofertas = CreateOferta().ToDictionary(t => t.Id);
        }

        public void AddOferta(Oferta oferta)
        {
            List<IOferta> ofertas = CreateOferta().ToList();
            ofertas.Add(oferta);
            _ofertas = ofertas.ToDictionary(t => t.Id);
        }

        private static IEnumerable<IOferta> CreateOferta()
        {
            yield return new Oferta(1, new Veiculo(2, "BMW", "Ricardo", "Cinza", 134000), 124000F);
            yield return new Oferta(2, new Veiculo(3, "VW", "Jorge", "Branco", 134000), 134000F);
        }

        public Dictionary<int, IOferta> GetAll()
        {
            return _ofertas;
        }


        public IOferta MaiorOferta()
        {
            var newP = CreateOferta().ToList().OrderByDescending(i => i.Valor).First();

            return newP;
            /* 
            _ofertas = ofertas.ToDictionary(t => t.Id); */
        }

    }
}