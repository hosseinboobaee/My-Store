using Application.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// GetAllProduct
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productService.GetAllProducts();
            if(products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("productId")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var productDetail = await _productService.GetProductById(productId);
            return Ok(productDetail);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product productDetail)
        {
            var productCreate = await _productService.CreateProduct(productDetail);
            if (productCreate)
            {
                return Ok(productCreate);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product productDetails)
        {
            if (productDetails != null)
            {
                var isProductCreated = await _productService.UpdateProduct(productDetails);
                if (isProductCreated)
                {
                    return Ok(isProductCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
