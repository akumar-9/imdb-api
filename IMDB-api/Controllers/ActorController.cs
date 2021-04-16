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
    [Route("actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var actors = _actorService.GetAll();
            return new JsonResult(actors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var actor = _actorService.Get(id);
            return new JsonResult(actor);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ActorRequest actorRequest)
        {
            var id =_actorService.Add(actorRequest);
            return Ok(new { Id = id });
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ActorRequest actorRequest, int id)
        {
            _actorService.Update(actorRequest, id);
            return Ok(new { Id = id });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _actorService.Delete(id);
            return Ok(new { Id = id });
        }
    }
}
