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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("create-product")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> CreateProduct([FromBody] Product Product)
        {
            await _productService.CreateProduct(Product);
            return Ok(JsonSerializer.Serialize("Product created with success!"));
        }

        [HttpGet]
        [Route("get-product-by-id/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] Guid id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPut]
        [Route("update-product")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> UpdateProduct([FromBody] Product Product)
        {
            await _productService.UpdateProduct(Product);
            return Ok(JsonSerializer.Serialize("Product updated with success!"));
        }

        [HttpDelete]
        [Route("remove-product/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> RemoveProduct([FromRoute] Guid id)
        {
            await _productService.RemoveProduct(id);
            return Ok(JsonSerializer.Serialize("Product removed with success!"));
        }
    }
}
