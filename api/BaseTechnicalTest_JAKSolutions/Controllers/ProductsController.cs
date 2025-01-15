using BaseTechnicalTest_JAKSolutions.Models.DTOs;
using BaseTechnicalTest_JAKSolutions.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaseTechnicalTest_JAKSolutions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductDTO productDTO)
        {
            _productService.Add(productDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDTO)
        {
            _productService.Update(id, productDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
