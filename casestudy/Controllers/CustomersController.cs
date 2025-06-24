using CaseStudy_Quitq.Models;
using CaseStudy_Quitq.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseStudy_Quitq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            if (customers == null || customers.Count == 0)
                return NotFound("No customers found.");
            return Ok(customers);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,customer")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");
            return Ok(customer);
        }

        [HttpGet("name/{name}")]
        [Authorize(Roles = "admin,customer")]
        public ActionResult<List<Customer>> GetCustomerByName(string name)
        {
            var customers = _customerService.GetCustomerByName(name);
            if (customers == null || customers.Count == 0)
                return NotFound("No customers with this name found.");
            return Ok(customers);
        }

        //[HttpGet("email/{email}")]
        //[Authorize(Roles = "Admin")]
        //public ActionResult<List<Customer>> GetCustomerByEmail(string email)
        //{
        //    var customers = _customerService.GetCustomerByEmail(email);
        //    if (customers == null || customers.Count == 0)
        //        return NotFound("No customers with this email found.");
        //    return Ok(customers);
        //}

        [HttpPost]
        public ActionResult<string> AddCustomer([FromBody] Customer customer)
        {
            var response = _customerService.AddCustomer(customer);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            var response = _customerService.UpdateCustomer(id, customer);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<string> DeleteCustomer(int id)
        {
            var response = _customerService.DeleteCustomer(id);
            return Ok(response);
        }
    }
}
