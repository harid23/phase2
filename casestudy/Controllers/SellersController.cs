using CaseStudy_Quitq.Models;
using CaseStudy_Quitq.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseStudy_Quitq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("get-all")]
        public ActionResult<List<Seller>> GetAllSellers()
        {
            var sellers = _sellerService.GetAllSellers();
            if (sellers == null)
                return NotFound("No sellers found.");
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public ActionResult<Seller> GetSellerById(int id)
        {
            var seller = _sellerService.GetSellerById(id);
            if (seller == null)
                return NotFound($"Seller with ID {id} not found.");
            return Ok(seller);
        }

        [HttpGet("by-name/{name}")]
        public ActionResult<List<Seller>> GetSellersByName(string name)
        {
            var sellers = _sellerService.GetSellersByName(name);
            if (sellers == null || sellers.Count == 0)
                return NotFound($"No sellers found with name {name}.");
            return Ok(sellers);
        }

        [Authorize(Roles = "admin, seller")]
        [HttpPost("add")]
        public ActionResult<string> AddSeller([FromBody] Seller seller)
        {
            var result = _sellerService.AddSeller(seller);
            return Ok(result);
        }


        [Authorize(Roles = "admin, eller")]
        [HttpPut("update/{id}")]
        public ActionResult<string> UpdateSeller(int id, [FromBody] Seller seller)
        {
            var result = _sellerService.UpdateSeller(id, seller);
            return Ok(result);
        }

        [Authorize(Roles = "admin, seller")]
        [HttpDelete("delete/{id}")]
        public ActionResult<string> DeleteSeller(int id)
        {
            var result = _sellerService.DeleteSeller(id);
            return Ok(result);
        }
    }
}
