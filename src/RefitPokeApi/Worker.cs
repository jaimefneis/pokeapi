using System.Text.Json;
using RefitPokeApi.Responses;
using RefitPokeApi.Services;

namespace PokeApi;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IPokeService _pokeService;

    public Worker(ILogger<Worker> logger, IPokeService pokeService)
    {
        _logger = logger;
        _pokeService = pokeService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        NamedAPIResourceList response = await _pokeService.GetAll();
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
        _logger.LogInformation(JsonSerializer.Serialize(response, options));

        foreach(NamedAPIResource result in response.Results)
        {
            Pokemon pokemon = await _pokeService.GetByName(result.Name);
            _logger.LogInformation(JsonSerializer.Serialize(pokemon, options));
        }
    }
}
