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
            var genre = _genreService.Get(id);
            return new JsonResult(genre);
        }

        [HttpPost]
        public IActionResult Add([FromBody] GenreRequest genreRequest)
        {
            var id =  _genreService.Add(genreRequest);
            return Ok(new { Id = id });
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] GenreRequest genreRequest, int id)
        {
            _genreService.Update(genreRequest,id);
            return Ok(new { Id = id });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _genreService.Delete(id);
            return Ok(new { Id = id });
        }
    }
}
