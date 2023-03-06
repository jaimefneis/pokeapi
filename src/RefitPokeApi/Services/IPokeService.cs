namespace RefitPokeApi.Services;

using Refit;
using RefitPokeApi.Responses;

public interface IPokeService
{
    [Get("/pokemon")]
    Task<NamedAPIResourceList> GetAll([Query] int? offset = 0, [Query] int? limit = 20);

    [Get("/pokemon/{name}")]
    Task<Pokemon> GetByName(string name);
}