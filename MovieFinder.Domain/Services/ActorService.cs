using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFinder.Data;
using MovieFinder.Data.Constraints;
using MovieFinder.Data.Entities;
using MovieFinder.Data.Extensions;
using MovieFinder.Domain.Helpers;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Domain.Services;

public class ActorService : IActorService
{
    private readonly DataContext _context;

    public ActorService(DataContext context)
    {
        _context = context;
    }

    public async Task<Actor> CreateActorAsync(string name, string surname, string country, int age, string base64)
    {
        var actor = new Actor
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Surname = surname,
            Country = country,
            Age = age,
            ImagePath = await ImageHelper.SaveImageAsync(base64)
        };

        await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();

        return actor;
    }

    public async Task<List<Actor>> GetActorsAsync(int pageSize, int pageNumber, string? searchQuery, string? sortQuery)
    {
        var actors = _context.Actors.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            actors = actors.Where(t =>
                (t.Name + t.Surname + t.Country + t.Age).ToLower().Contains(searchQuery.ToLower()));
        }

        actors = sortQuery switch
        {
            SortConstraints.AgeAscending => actors.OrderBy(t => t.Age),
            SortConstraints.AgeDescending => actors.OrderByDescending(t => t.Age),
            SortConstraints.NameAscending => actors.OrderBy(t => t.Name),
            SortConstraints.NameDescending => actors.OrderByDescending(t => t.Name),
            _ => actors
        };

        return await actors.Page(pageSize, pageNumber).ToListAsync();
    }
    
}