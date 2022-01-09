namespace MovieFinder.Application.Models.Requests;

public class MarkRequest
{
    public string MovieId { get; set; }
    public string UserId { get; set; }
    public int Value { get; set; }
}