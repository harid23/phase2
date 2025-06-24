using CaseStudy_Quitq.Models;
using CaseStudy_Quitq.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CaseStudy_Quitq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("get-order-by-id/{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order != null)
                return Ok(order);
            return NotFound($"Order with ID {id} not found");
        }

        [HttpGet("get-orders-by-customer-id/{customerId}")]
        public IActionResult GetOrdersByCustomerId(int customerId)
        {
            var orders = _orderService.GetOrdersByCustomerId(customerId);
            return Ok(orders);
        }

        [HttpGet("get-orders-by-product-id/{productId}")]
        public IActionResult GetOrdersByProductId(int productId)
        {
            var orders = _orderService.GetOrdersByProductId(productId);
            return Ok(orders);
        }

        [Authorize(Roles = "admin,seller")]
        [HttpGet("get-orders-by-seller-id/{productId}")]
        public IActionResult GetOrdersBySellerId(int sellerId)
        {
            var orders = _orderService.GetOrdersBySellerId(sellerId);
            return Ok(orders);
        }

        [HttpPost("place")]
        [Authorize(Roles = "customer")]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            try
            {
                var placedOrder = _orderService.PlaceOrder(order);
                return Ok(placedOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Message = ex.Message });
            }
        }

        [Authorize(Roles = "admin,seller")]
        [HttpPut("update-status/{orderId}")]
        public IActionResult UpdateOrderStatus(int orderId, [FromBody] string newStatus)
        {
            try
            {
                var result = _orderService.UpdateOrderStatus(orderId, newStatus);
                if (result == null)
                    return NotFound($"Order with ID {orderId} not found or update failed.");

                return Ok(new { Message = "Order status updated", UpdatedOrder = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("delete-order/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var result = _orderService.CancelOrder(id);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("get-total-order-count")]
        public IActionResult GetOrderCount()
        {
            var count = _orderService.GetTotalOrderCount();
            return Ok(count);
        }
    }
}
