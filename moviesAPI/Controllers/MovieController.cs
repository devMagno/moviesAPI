using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Models;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> _movies = new();
        private static int _id = 1;

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            movie.Id = _id++;
            _movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { _id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_movies);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = _movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound();
        }
    }
}