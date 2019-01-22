using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Demo.Core.Entities;
using Architecture.Demo.Core.Entities.DTO;
using Architecture.Demo.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(404)] //not found
        [ProducesResponseType(500)] //server error
        public IActionResult Get([FromRoute] int id)
        {
            var data = _customerService.Get(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Customer), 201)]
        [ProducesResponseType(400)] //bad request
        [ProducesResponseType(500)] //server error
        public IActionResult Post([FromBody] CustomerDTO customer)
        {
            var data = _customerService.Add(customer);
            return Created(nameof(Get), data);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Customer), 202)]
        [ProducesResponseType(404)] //not found
        [ProducesResponseType(409)] //conflict
        public IActionResult Put([FromRoute] int id, [FromBody] CustomerDTO customer)
        {
            var data = _customerService.Get(id);
            if (data == null)
                return NotFound();

            return Accepted(_customerService.Update(id, customer));
        }
    }
}