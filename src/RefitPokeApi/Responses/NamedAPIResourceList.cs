
namespace RefitPokeApi.Responses;

public record NamedAPIResourceList(int Count, string Next, string Previous, IReadOnlyList<NamedAPIResource> Results);