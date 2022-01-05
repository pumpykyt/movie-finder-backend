using AutoMapper;
using MovieFinder.Application.Models.Requests;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Data.Entities;

namespace MovieFinder.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MovieRequest, Movie>();
        CreateMap<Movie, MovieResponse>();
    }
}