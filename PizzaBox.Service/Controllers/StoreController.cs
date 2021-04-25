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
        public ActionResult<AStore> Get()
        {
            return Ok(_repository.GetAllStores());
        }

        [HttpGet("{id}")]
        public ActionResult<AStore> GetById(int sid)
        {
            var store = _repository.GetAllStores().Find(s => s.StoreId == sid);
            if (store == null)
            {
                return NotFound($"The store with id {sid} was not found in the database.");
            }
            return Ok(store);
        }

        [HttpPost]
        public IActionResult Post(AStore store)
        {
            if (store != null)
            {
                _repository.GetAllStores().Add(store);
                return NoContent();
            }
            return BadRequest("Store data is invalid or null");
        }
    }
}