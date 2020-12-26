using BilgeAdam.SecuredApp.Services.Abstractions;
using BilgeAdam.SecuredApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeAdam.SecuredApp.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        [HttpGet("one")]
        public IActionResult Get([FromQuery] int id)
        {
            var product = service.GetOne(id);
            if (product == null)
            {
                return BadRequest("product not found");
            }
            return Ok(product);
        }

        [HttpGet("list")]
        public IActionResult List([FromQuery] int page, [FromQuery] int count)
        {
            if (page <= 0 || count <= 0)
            {
                return BadRequest("check request parameters");
            }
            return Ok(service.GetMany(page, count));
        }
    }
}
