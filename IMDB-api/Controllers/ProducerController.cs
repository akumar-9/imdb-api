using IMDB_api.Models.DB;
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
    [Route("producers")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var producers = _producerService.GetAll();
            return new JsonResult(producers);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_producerService.Get(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProducerRequest producerRequest)
        {
            _producerService.Add(producerRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ProducerRequest producerRequest, int id)
        {
            _producerService.Update(producerRequest, id);
            return Ok(new { Id = id });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _producerService.Delete(id);
            return Ok(new { Id = id });
        }
    }
}
