using CaseStudy_Quitq.Contexts;
using CaseStudy_Quitq.Models;
using CaseStudy_Quitq.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy_Quitq.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllCustomers: " + ex.Message);
            }
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetCustomerById: " + ex.Message);
            }
        }

        public List<Customer> GetCustomerByName(string name)
        {
            try
            {
                return _context.Customers
                    .Where(c => !string.IsNullOrEmpty(c.CustomerName) && c.CustomerName.ToLower().Contains(name.ToLower()))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetCustomerByName: " + ex.Message);
            }
        }

        //public List<Customer> GetCustomerByEmail(string email)
        //{
        //    try
        //    {
        //        return _context.Customers
        //            .Where(c => !string.IsNullOrEmpty(c.Email) && c.Email.ToLower().Contains(email.ToLower()))
        //            .ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in GetCustomerByEmail: " + ex.Message);
        //    }
        //}

        public string AddCustomer(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    return "Customer added successfully.";
                }
                return "Invalid customer data.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddCustomer: " + ex.Message);
            }
        }

        public string UpdateCustomer(int id, Customer customer)
        {
            try
            {
                var existing = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
                if (existing == null)
                    return $"Customer with ID {id} not found.";

                existing.CustomerName = customer.CustomerName;
                existing.Phone = customer.Phone;
                existing.Address = customer.Address;

                _context.SaveChanges();
                return $"Customer with ID {id} updated successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UpdateCustomer: " + ex.Message);
            }
        }

        public string DeleteCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
                if (customer == null)
                    return $"Customer with ID {id} not found.";

                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return "Customer deleted successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteCustomer: " + ex.Message);
            }
        }
    }
}
