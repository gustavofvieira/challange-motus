using Develop.Store.Domain.Interfaces.Services;
using Develop.Store.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Develop.Store.Web.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
              
        [HttpPost]
        [Route("create-customer")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> CreateCustomer([FromBody] Customer customer)
        {
            await _customerService.CreateCustomer(customer);
            return Ok(JsonSerializer.Serialize("Customer created with success!"));
        }

        [HttpGet]
        [Route("get-customer-by-id/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Customer>> GetCustomerById([FromRoute] Guid id)
        {
            return Ok(await _customerService.GetCustomerById(id));
        }

        [HttpPut]
        [Route("update-customer")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> UpdateCustomer([FromBody] Customer customer)
        {
            await _customerService.UpdateCustomer(customer);
            return Ok(JsonSerializer.Serialize("Customer updated with success!"));
        }

        [HttpDelete]
        [Route("remove-customer/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> RemoveCustomer([FromRoute] Guid id)
        {
            await _customerService.RemoveCustomer(id);
            return Ok(JsonSerializer.Serialize("Customer removed with success!"));
        }
    }
}
