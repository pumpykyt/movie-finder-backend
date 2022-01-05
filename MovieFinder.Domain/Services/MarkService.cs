using System.Net;
using Microsoft.EntityFrameworkCore;
using MovieFinder.Data;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Exceptions;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Domain.Services;

public class MarkService : IMarkService
{
    private readonly DataContext _context;

    public MarkService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<double> CreateMarkAsync(string movieId, int value)
    {
        var movie = await _context.Movies.SingleOrDefaultAsync(t => t.Id == movieId);
        if (movie is null) throw new HttpStatusException(HttpStatusCode.NotFound, "Movie not found");
        
        var mark = new Mark
        {
            Id = Guid.NewGuid().ToString(),
            MovieId = movieId,
            Value = value
        };
        
        movie.RatesCount++;
        movie.Rating = (movie.Rating + value) / 2;

        await _context.Marks.AddAsync(mark);
        await _context.SaveChangesAsync();

        return movie.Rating;
    }
    
    public async Task<double> DeleteMarkAsync(string markId)
    {
        var mark = await _context.Marks.SingleOrDefaultAsync(t => t.Id == markId);
        if (mark is null) throw new HttpStatusException(HttpStatusCode.NotFound, "Mark not found");

        var movie = await _context.Movies.SingleOrDefaultAsync(t => t.Id == mark.MovieId);
        if (movie is null) throw new HttpStatusException(HttpStatusCode.NotFound, "Movie not found");

        movie.RatesCount--;
        movie.Rating = (movie.Rating * (double)movie.RatesCount - mark.Value) / (double)movie.RatesCount;

        _context.Marks.Remove(mark);
        await _context.SaveChangesAsync();

        return movie.Rating;
    }
}