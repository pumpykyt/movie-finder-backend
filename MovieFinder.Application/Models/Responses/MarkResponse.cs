namespace MovieFinder.Application.Models.Responses;

public class MarkResponse
{
    public string Id { get; set; }
    public int Value { get; set; }
    public string MovieName { get; set; }
    public string Username { get; set; }
    public DateTime Created { get; set; }
    public string MovieImagePath { get; set; }
}