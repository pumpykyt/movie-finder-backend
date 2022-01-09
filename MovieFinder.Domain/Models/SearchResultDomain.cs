using MovieFinder.Data.Entities;

namespace MovieFinder.Domain.Models;

public class SearchResultDomain
{
    public List<Actor> Actors { get; set; }
    public List<Movie> Movies { get; set; }
}