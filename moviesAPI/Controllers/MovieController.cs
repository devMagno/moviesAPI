using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Models;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> _movies = new();

        [HttpPost]
        public void AddMovie([FromBody] Movie movie)
        {
            _movies.Add(movie);
            Console.WriteLine(movie.Title);
        }
    }
}