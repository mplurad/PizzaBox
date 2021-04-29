using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain;
using System.Net.Mime;

namespace PizzaBox.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IRepository _repository;
        public StoreController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AStore> Get()
        {
            try
            {
                return Ok(_repository.GetAllStores());
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("{sid}")]//https://localhost:5001/api/Store/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AStore> GetById([FromRoute] int sid)
        {
            try
            {
                var store = _repository.GetStore(sid);
                if (store == null)
                {
                    return NotFound($"The store with id {sid} was not found in the database.");
                }
                return Ok(store);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post([FromBody] AStore store)
        {
            try
            {
                if (store == null || store.StoreLocation == null)
                    return BadRequest("Store data is invalid or null");
                if (store.StoreLocation.Length == 0)
                    return BadRequest("Store data is invalid or null");
                _repository.AddStore(store);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put([FromBody] AStore store)
        {
            try
            {
                if (store == null || store.StoreLocation == null)
                    return BadRequest("Store data is invalid or null");
                if (store.StoreLocation.Length == 0)
                    return BadRequest("Store data is invalid or null");
                _repository.UpdateStore(store);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (_repository.GetStore(id) == null)
                    return BadRequest("Store does not exist");
                _repository.DeleteStore(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
