using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using ApiGraphQL.Repositories;
using HotChocolate.Subscriptions;
using ApiGraphQL.Veiculos;

namespace ApiGraphQL.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class VeiculosMutation
    {
        public async Task<Veiculo> CreateVeiculo(
            Veiculo input, [Service] IVeiculoRepository repository,
            [Service] ITopicEventSender eventSender)
        {
            var veiculo = new Veiculo(input.Id, input.Nome, input.Dono, input.Cor, input.Preco);
            repository.AddVeiculo(veiculo);
            // envio um evento para veiculos e falo a nova adição.            
            await eventSender.SendAsync(nameof(VeiculosSubscription.VeiculoAdicionado), veiculo).ConfigureAwait(false);
            return input;
        }

        public async Task<Oferta> ReceberOfertaVeiculo(
            Oferta input, [Service] IOfertaRepository repository,
            [Service] ITopicEventSender eventSender)
        {
            var oferta = new Oferta(input.Id, input.Veiculo, input.Valor);
            repository.AddOferta(oferta);
            var maiorOferta = repository.MaiorOferta();
            // envio um evento para veiculos e falo a nova adição.            
            await eventSender.SendAsync(nameof(OfertaSubscription.OfertaMaior), maiorOferta).ConfigureAwait(false);
            return input;
        }



        // public Veiculo CreateVeiculo(
        //     Veiculo input,
        //     [Service] IVeiculoRepository repository)
        // {
        //     var veiculo = new Veiculo(input.Id, input.Nome, input.Dono, input.Cor, input.Preco);
        //     repository.AddVeiculo(veiculo);

        //     return input;

        // }
    }
}