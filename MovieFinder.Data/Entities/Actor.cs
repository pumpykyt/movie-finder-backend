using System.Collections.Generic;

namespace MovieFinder.Data.Entities;

public class Actor
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Country { get; set; }
    public int Age { get; set; }
    public string ImagePath { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}