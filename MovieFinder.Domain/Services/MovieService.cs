using Microsoft.EntityFrameworkCore;
using MovieFinder.Data;
using MovieFinder.Data.Constraints;
using MovieFinder.Data.Entities;
using MovieFinder.Data.Extensions;
using MovieFinder.Domain.Helpers;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Domain.Services;

public class MovieService : IMovieService
{
    private readonly DataContext _context;

    public MovieService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Movie> CreateMovieAsync(string name, string description, string country, int budget, string director, string base64)
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid().ToString(),
            Rating = 1,
            RatesCount = 0,
            Name = name,
            Description = description,
            Country = country,
            Budget = budget,
            Director = director,
            ImagePath = await ImageHelper.SaveImageAsync(base64)
        };

        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task<List<Movie>> GetMoviesAsync(int pageSize, int pageNumber, string? searchQuery, string? sortQuery)
    {
        var movies = _context.Movies.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            movies = movies.Where(t =>
                (t.Name + t.Director + t.Country + t.Year).ToLower().Contains(searchQuery.ToLower()));
        }

        switch (sortQuery)
        {
            case SortConstraints.BudgetAscending:
                movies = movies.OrderBy(t => t.Budget);
                break;
            case SortConstraints.BudgetDescending:
                movies = movies.OrderByDescending(t => t.Budget);
                break;
            case SortConstraints.YearAscending:
                movies = movies.OrderBy(t => t.Year);
                break;
            case SortConstraints.YearDescending:
                movies = movies.OrderByDescending(t => t.Year);
                break;
            case SortConstraints.NameAscending:
                movies = movies.OrderBy(t => t.Name);
                break;
            case SortConstraints.NameDescending:
                movies = movies.OrderByDescending(t => t.Name);
                break;
            default:
                break;
        }

        return await movies.Page(pageSize, pageNumber).ToListAsync();
    }
}