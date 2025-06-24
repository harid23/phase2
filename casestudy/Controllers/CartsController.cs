using CaseStudy_Quitq.Models;
using CaseStudy_Quitq.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy_Quitq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartsController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{customerId}")]
        [Authorize(Roles = "customer")]
        public IActionResult GetCart(int customerId)
        {
            var cart = _cartService.GetCartByCustomerId(customerId);
            if (cart == null)
                return NotFound("Cart not found.");
            return Ok(cart);
        }

        [HttpPost("add")]
        [Authorize(Roles = "customer")]
        public IActionResult AddToCart(int customerId, int productId, int quantity)
        {
            var result = _cartService.AddToCart(customerId, productId, quantity);
            return Ok(result);
        }

        [HttpDelete("remove")]
        [Authorize(Roles = "customer")]
        public IActionResult RemoveFromCart(int customerId, int productId)
        {
            var result = _cartService.RemoveFromCart(customerId, productId);
            return Ok(result);
        }

        [HttpDelete("clear/{customerId}")]
        [Authorize(Roles = "customer")]
        public IActionResult ClearCart(int customerId)
        {
            var result = _cartService.ClearCart(customerId);
            return Ok(result);
        }
    }
}
