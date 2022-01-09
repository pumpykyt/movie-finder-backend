using MediatR;
using MovieFinder.Application.Models.Responses;

namespace MovieFinder.Application.Commands;

public class CreateMarkCommand : IRequest<MarkResponse>
{
    public string MovieId { get; set; }
    public string UserId { get; set; }
    public int Value { get; set; }
    
    public CreateMarkCommand(string movieId, string userId, int value)
    {
        MovieId = movieId;
        UserId = userId;
        Value = value;
    }
}