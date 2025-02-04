using Develop.Store.Domain.DTO;
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
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
              
        [HttpPost]
        [Route("add-sale")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> AddSale([FromBody] SaleDTO saleDto)
        {
            await _saleService.AddSale(saleDto);
            return Ok(JsonSerializer.Serialize("Account created with success!"));
        }
    }
}
