using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaBox.Domain.Models;
using PizzaBox.Domain;

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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AStore> GetById(int sid)
        {
            try
            {
                var store = _repository.GetAllStores().Find(s => s.StoreId == sid);
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
        public IActionResult Post(AStore store)
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
        public IActionResult Put(AStore store)
        {
            try
            {
                if (store == null || store.StoreLocation == null)
                    return BadRequest("Store data is invalid or null");
                if (store.StoreLocation.Length == 0)
                    return BadRequest("Store data is invalid or null");
                _repository.Update(store);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int storeID)
        {
            try
            {
                if (storeID <= 0)
                    return BadRequest("Store does not exist");
                _repository.DeleteStore(storeID);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}