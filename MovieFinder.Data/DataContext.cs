using Microsoft.EntityFrameworkCore;
using MovieFinder.Data.Entities;

namespace MovieFinder.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Mark> Marks { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
}