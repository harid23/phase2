using CaseStudy_Quitq.Models;
using CaseStudy_Quitq.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseStudy_Quitq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return products == null ? NotFound("No products found.") : Ok(products);
        }

        [HttpGet("by-id/{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            return product == null ? NotFound("Product not found.") : Ok(product);
        }

        [HttpGet("by-name/{name}")]
        public ActionResult<List<Product>> GetByName(string name)
        {
            var result = _productService.GetProductByName(name);
            return result == null ? NotFound("No matching products.") : Ok(result);
        }

        [HttpGet("by-category/{category}")]
        public ActionResult<List<Product>> GetByCategory(string category)
        {
            var result = _productService.GetProductsByCategory(category);
            return result == null ? NotFound("No products found in this category.") : Ok(result);
        }

        [HttpGet("by-price/{price}")]
        public ActionResult<List<Product>> GetByPrice(int price)
        {
            var result = _productService.GetProductsByPrice(price);
            return result == null ? NotFound("No products match this price.") : Ok(result);
        }

        [Authorize(Roles = "admin,seller")]
        [HttpGet("in-stock")]
        public ActionResult<List<Product>> GetInStock()
        {
            return Ok(_productService.GetProductsInStock());
        }

        [Authorize(Roles = "admin,seller")]
        [HttpGet("low-stock/{threshold}")]
        public ActionResult<List<Product>> GetLowStock(int threshold)
        {
            return Ok(_productService.GetLowStockProducts(threshold));
        }

        [Authorize(Roles = "admin,seller")]
        [HttpPost("add")]
        public ActionResult<string> AddProduct(Product product)
        {
            return Ok(_productService.AddProduct(product));
        }

        [Authorize(Roles = "admin,seller")]
        [HttpPut("update/{id}")]
        public ActionResult<string> UpdateProduct(int id, Product product)
        {
            return Ok(_productService.UpdateProduct(id, product));
        }

        [Authorize(Roles = "admin,seller")]
        [HttpDelete("delete/{id}")]
        public ActionResult<string> DeleteProduct(int id)
        {
            return Ok(_productService.DeleteProduct(id));
        }

        [Authorize(Roles = "admin,seller")]
        [HttpGet("by-seller/{sellerId}")]
        public ActionResult<List<Product>> GetBySellerId(int sellerId)
        {
            return Ok(_productService.GetProductsBySellerId(sellerId));
        }
    }
}
