namespace MovieFinder.Data.Entities;

public class Movie
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public int Budget { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public double Rating { get; set; }
    public int RatesCount { get; set; }
    public string ImagePath { get; set; }
    public virtual ICollection<Actor> Actors { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Mark> Marks { get; set; } 
}