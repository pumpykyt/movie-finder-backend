using Microsoft.EntityFrameworkCore;
using MovieFinder.Data;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Interfaces;
using MovieFinder.Domain.Models;

namespace MovieFinder.Domain.Services;

public class SearchService : ISearchService
{
    private readonly DataContext _context;

    public SearchService(DataContext context)
    {
        _context = context;
    }

    public async Task<SearchResultDomain> SearchActorsAndMoviesAsync(string? searchQuery)
    {
        var actors = _context.Actors.AsQueryable();
        var movies = _context.Movies.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            actors = actors.Where(t => 
                (t.Name + t.Surname + t.Country).ToLower().Contains(searchQuery.ToLower()));
            movies = movies.Where(t =>
                (t.Name + t.Description + t.Country + t.Director + t.Year).ToLower().Contains(searchQuery.ToLower()));
            
            return new SearchResultDomain
            {
                Actors = await actors.ToListAsync(),
                Movies = await movies.ToListAsync()
            };
        }

        return new SearchResultDomain
        {
            Actors = new List<Actor>(),
            Movies = new List<Movie>()
        };
    }

    public Task<List<User>> SearchUsersAsync(string username)
    {
        throw new NotImplementedException();
    }
}