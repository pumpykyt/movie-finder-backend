namespace MovieFinder.Domain.Interfaces;

public interface IRoleService
{
    Task<string> CreateRoleAsync(string name);
}