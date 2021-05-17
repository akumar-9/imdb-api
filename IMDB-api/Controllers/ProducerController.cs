using IMDB_api.Models.Requests;
using IMDB_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            try
            {   var producer = _producerService.Get(id);
                return new JsonResult(producer);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProducerRequest producerRequest)
        {
            try 
            {
                var id = _producerService.Add(producerRequest);
                return Ok(new { Id = id });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ProducerRequest producerRequest, int id)
        {
            try
            {
                _producerService.Update(producerRequest, id);
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
                _producerService.Delete(id);
                return Ok(new { Id = id });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
