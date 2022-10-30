using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IDataService _dataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public ProductsController(IDataService dataService, LinkGenerator generator, IMapper mapper)
        {
            _dataService = dataService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductsById(int id)
        {
            var product = _dataService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("name/{search}")]
        public IActionResult GetProductsByName(string search)
        {
            var product = _dataService.GetProductByName(search);
            if (product.Count == 0)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("category/{id}")]
        public IActionResult GetProductsByCategory(int id)
        {
            var product = _dataService.GetProductByCategory(id);
            if (product.Count == 0)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}

