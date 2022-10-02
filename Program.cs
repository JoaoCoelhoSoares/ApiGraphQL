using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiGraphQL.Repositories;
using ApiGraphQL.Veiculos;
using ApiGraphQL.Mensagens;

var builder = WebApplication.CreateBuilder(args);

builder.Services

    .AddSingleton<IVeiculoRepository, VeiculoRepository>()

    .AddGraphQLServer()

    // Queries
    .AddQueryType()
        .AddTypeExtension<VeiculosQueries>()

    // Mutations
    .AddMutationType()
        .AddTypeExtension<VeiculosMutation>()

    // Subscriptions
    .AddSubscriptionType()
        .AddTypeExtension<VeiculosSubscription>()
        .AddTypeExtension<OfertaSubscription>()

    .AddType<Veiculo>()
    .AddType<Comprador>()
    .AddType<Friend>()
    .AddType<Oferta>()

    .AddInMemorySubscriptions()
    .AddApolloTracing();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corsapp");

// app.MapGraphQL();

// Adicionando o "suporte" ao WebSockets em graphql
app.UseWebSockets()
    .UseRouting()
    .UseEndpoints(endpoint => endpoint.MapGraphQL());

app.Run();
