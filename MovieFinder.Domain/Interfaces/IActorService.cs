using MovieFinder.Data.Entities;

namespace MovieFinder.Domain.Interfaces;

public interface IActorService
{
    Task<Actor> CreateActorAsync(string name, string surname, string country, int age, string base64);
    Task<List<Actor>> GetActorsAsync(int pageSize, int pageNumber, string? searchQuery, string? sortQuery);
}