using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Data;
using moviesAPI.Data.DTOs;
using moviesAPI.Models;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDTO movieDTO)
        {
            Movie movie = _mapper.Map<Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new { _id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                ReadMovieDTO movieDTO = _mapper.Map<ReadMovieDTO>(movie);
                return Ok(movieDTO);
            }

            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateMovieById(int id, [FromBody] UpdateMovieDTO movieDTO)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _mapper.Map(movieDTO, movie);
            movie.Title = movieDTO.Title;
            movie.Genre = movieDTO.Genre;
            movie.Director = movieDTO.Director;
            movie.Duration = movieDTO.Duration;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteMovieById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}