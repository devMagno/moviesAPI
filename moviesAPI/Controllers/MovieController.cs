using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Data;
using moviesAPI.Models;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
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
                return Ok(movie);
            }

            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateMovieById(int id, [FromBody] Movie updatedMovie)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = updatedMovie.Title;
            movie.Genre = updatedMovie.Genre;
            movie.Director = updatedMovie.Director;
            movie.Duration = updatedMovie.Duration;
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