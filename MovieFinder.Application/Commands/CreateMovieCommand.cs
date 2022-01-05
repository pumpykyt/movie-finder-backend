using MediatR;
using MovieFinder.Application.Models.Responses;

namespace MovieFinder.Application.Commands;

public class CreateMovieCommand : IRequest<MovieResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public int Budget { get; set; }
    public string Director { get; set; }
    public string Base64 { get; set; }

    public CreateMovieCommand(string name, string description, string country, int budget, 
        string director, string base64)
    {
        Name = name;
        Description = description;
        Country = country;
        Budget = budget;
        Director = director;
        Base64 = base64;
    }
}