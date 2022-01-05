using MovieFinder.Data.Entities;

namespace MovieFinder.Domain.Interfaces;

public interface IMovieService
{
    Task<Movie> CreateMovieAsync(string name, string description, string country, int budget, string director, string base64);
    Task<List<Movie>> GetMoviesAsync(int pageSize, int pageNumber, string? searchQuery, string? sortQuery);
    
}