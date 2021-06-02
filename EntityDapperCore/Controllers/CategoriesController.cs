using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using EntityDapperCore.BusinessLayer.Services;
using EntityDapperCore.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityDapperCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetList(bool includeProducts = false)
        {
            var products = await categoryService.GetAsync(includeProducts);
            return Ok(products);
        }
    }
}
