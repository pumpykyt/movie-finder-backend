namespace MovieFinder.Domain.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(string email, string password, string username);
    Task<string> LoginAsync(string email, string password);
}