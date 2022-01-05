using System.Linq;

namespace MovieFinder.Data.Extensions;

public static class Extensions
{
    public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageSize, int pageNumber) => 
        query.Skip((pageNumber - 1) * pageSize)
             .Take(pageSize);
}