using PokeApi;
using Refit;
using RefitPokeApi.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services
            .AddRefitClient<IPokeService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://pokeapi.co/api/v2"));
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
