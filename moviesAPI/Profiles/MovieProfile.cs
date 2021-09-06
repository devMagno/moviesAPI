using AutoMapper;
using moviesAPI.Data;
using moviesAPI.Data.DTOs;
using moviesAPI.Models;

namespace moviesAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<Movie, ReadMovieDTO>();
            CreateMap<UpdateMovieDTO, Movie>();
        }
    }
}