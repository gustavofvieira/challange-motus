using Develop.Store.Domain.Interfaces.Services;
using Develop.Store.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Route("add-customer")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> AddCustomer([FromBody] Customer customer)
        {
            await _customerService.AddCustomer(customer);
            return Ok(JsonSerializer.Serialize("Account created with success!"));
        }
    }
}
