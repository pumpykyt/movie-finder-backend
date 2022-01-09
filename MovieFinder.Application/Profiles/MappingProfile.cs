using AutoMapper;
using MovieFinder.Application.Models.Requests;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Models;

namespace MovieFinder.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MovieRequest, Movie>();
        CreateMap<Movie, MovieResponse>();
        CreateMap<Mark, MarkResponse>().ForMember(dest => dest.MovieName, 
                                                  src => src.MapFrom(t => t.Movie.Name))
                                       .ForMember(dest => dest.MovieImagePath, 
                                                  src => src.MapFrom(t => t.Movie.ImagePath));
        CreateMap<ActorRequest, Actor>();
        CreateMap<Actor, ActorResponse>();
        CreateMap<SearchResultDomain, SearchResultResponse>();
    }
}