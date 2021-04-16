using IMDB_api.Models.Requests;
using IMDB_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var id =_producerService.Add(producerRequest);
            return Ok(new { Id = id });
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
