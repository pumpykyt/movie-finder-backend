namespace MovieFinder.Application.Models.Requests;

public class ActorRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Country { get; set; }
    public int Age { get; set; }
    public string Base64 { get; set; }
}