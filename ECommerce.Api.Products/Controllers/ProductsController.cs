using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider _productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            _productsProvider = productsProvider;
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the all products</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _productsProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound();
        }


        /// <summary>
        /// Gets the product by the provided id
        /// </summary>
        /// <param name="id">The proudct id of the product being requested</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested product</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await _productsProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}
