namespace MovieFinder.Application.Models.Responses;

public class MovieResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public int Budget { get; set; }
    public string Director { get; set; }
    public double Rating { get; set; }
    public int RatesCount { get; set; }
    public string ImagePath { get; set; }
}