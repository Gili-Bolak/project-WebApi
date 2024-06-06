using AutoMapper;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductService _productService;
        private IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get([FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds, [FromQuery] string? productName)
        {
            List<Product> products = await _productService.GetAllProducts(minPrice, maxPrice, categoryIds, productName);
            if(products == null)
            {
                return NotFound();
            }
         
           List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
           return Ok(productsDto);
        }


    }
}
