namespace MovieFinder.Application.Models.Requests;

public class MovieRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public int Budget { get; set; }
    public string Director { get; set; }
    public string Base64 { get; set; }
}