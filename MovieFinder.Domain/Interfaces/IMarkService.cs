using MovieFinder.Data.Entities;

namespace MovieFinder.Domain.Interfaces;

public interface IMarkService
{
    Task<Mark> CreateMarkAsync(string movieId, string userId, int value);
    Task<double> DeleteMarkAsync(string markId);
    Task<List<Mark>> GetUserMarksAsync(string userId);
}