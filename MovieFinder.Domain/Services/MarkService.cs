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
    
    public async Task<Mark> CreateMarkAsync(string movieId, string userId, int value)
    {
        var movie = await _context.Movies.SingleOrDefaultAsync(t => t.Id == movieId);
        if (movie is null) throw new HttpStatusException(HttpStatusCode.NotFound, "Movie not found");
        
        var user = await _context.Users.SingleOrDefaultAsync(t => t.Id == userId);
        if (movie is null) throw new HttpStatusException(HttpStatusCode.NotFound, "User not found");
        
        var mark = new Mark
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            MovieId = movieId,
            UserId = userId,
            Movie = movie,
            User  = user,
            Value = value
        };
        
        movie.RatesCount++;
        
        if (movie.RatesCount == 1)
        {
            movie.Rating = value;
        }
        else
        {
           movie.Rating = (movie.Rating + value) / 2; 
        }

        await _context.Marks.AddAsync(mark);
        await _context.SaveChangesAsync();

        return mark;
    }
    
    public async Task<double> DeleteMarkAsync(string markId)
    {
        var mark = await _context.Marks.SingleOrDefaultAsync(t => t.Id == markId);
        if (mark is null) throw new HttpStatusException(HttpStatusCode.NotFound, "Mark not found");

        var movie = await _context.Movies.SingleOrDefaultAsync(t => t.Id == mark.MovieId);
        if (movie is null) throw new HttpStatusException(HttpStatusCode.NotFound, "Movie not found");

        movie.RatesCount--;
        movie.Rating = (movie.Rating * movie.RatesCount - mark.Value) / movie.RatesCount;

        _context.Marks.Remove(mark);
        await _context.SaveChangesAsync();

        return movie.Rating;
    }

    public async Task<List<Mark>> GetUserMarksAsync(string userId)
    {
        var userExists = await _context.Users.AnyAsync(t => t.Id == userId);
        if (!userExists) throw new HttpStatusException(HttpStatusCode.NotFound, "User not found");
        
        return await _context.Marks.Include(t => t.Movie)
                                   .Include(t => t.User)
                                   .Where(t => t.UserId == userId)
                                   .ToListAsync();
    }
}