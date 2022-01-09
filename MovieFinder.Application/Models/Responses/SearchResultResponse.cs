namespace MovieFinder.Application.Models.Responses;

public class SearchResultResponse
{
    public List<MovieResponse> Movies { get; set; }
    public List<ActorResponse> Actors { get; set; }
    public int TotalCount { get; set; }
}