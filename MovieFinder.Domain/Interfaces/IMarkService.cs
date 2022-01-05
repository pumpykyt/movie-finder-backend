namespace MovieFinder.Domain.Interfaces;

public interface IMarkService
{
    Task<double> CreateMarkAsync(string movieId, int value);
    Task<double> DeleteMarkAsync(string markId);
}