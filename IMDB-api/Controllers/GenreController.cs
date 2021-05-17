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
    [Route("genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var genres = _genreService.GetAll();
            return new JsonResult(genres);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try 
            {
                var genre = _genreService.Get(id);
                return new JsonResult(genre);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] GenreRequest genreRequest)
        {
            try
            {
                var id = _genreService.Add(genreRequest);
                return Ok(new { Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] GenreRequest genreRequest, int id)
        {
            try
            {
                _genreService.Update(genreRequest, id);
                return Ok(new { Id = id });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _genreService.Delete(id);
                return Ok(new { Id = id });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
