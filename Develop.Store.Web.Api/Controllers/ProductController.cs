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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
              
        [HttpPost]
        [Route("add-product")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> AddSale([FromBody] Product product)
        {
            await _productService.AddProduct(product);
            return Ok(JsonSerializer.Serialize("Account created with success!"));
        }
    }
}
