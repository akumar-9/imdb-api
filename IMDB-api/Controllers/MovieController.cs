using IMDB_api.Models.Requests;
using IMDB_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAll();
            return new JsonResult(movies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _movieService.Get(id);
            return new JsonResult(movie);
        }

        [HttpPost]
        public IActionResult Add([FromBody] MovieRequest movieRequest)
        {
            _movieService.Add(movieRequest);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] MovieRequest movieRequest, int id)
        {
            _movieService.Update(movieRequest, id);
            return Ok(new { Id = id });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok(new { Id = id });
        }
    }
}
