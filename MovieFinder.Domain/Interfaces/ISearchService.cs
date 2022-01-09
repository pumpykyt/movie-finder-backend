using MovieFinder.Data.Entities;
using MovieFinder.Domain.Models;

namespace MovieFinder.Domain.Interfaces;

public interface ISearchService
{
    Task<SearchResultDomain> SearchActorsAndMoviesAsync(string? searchQuery);
    Task<List<User>> SearchUsersAsync(string username);
}