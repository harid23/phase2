using CaseStudy_Quitq.Models;
using CaseStudy_Quitq.Repository;
using CaseStudy_Quitq.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy_Quitq.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _customerRepository.GetAllCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in GetAllCustomers: " + ex.Message);
            }
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return _customerRepository.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in GetCustomerById: " + ex.Message);
            }
        }

        public List<Customer> GetCustomerByName(string name)
        {
            try
            {
                return _customerRepository.GetCustomerByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in GetCustomerByName: " + ex.Message);
            }
        }

        //public List<Customer> GetCustomerByEmail(string email)
        //{
        //    try
        //    {
        //        return _customerRepository.GetCustomerByEmail(email);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception in GetCustomerByEmail: " + ex.Message);
        //    }
        //}

        public string AddCustomer(Customer customer)
        {
            try
            {
                return _customerRepository.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in AddCustomer: " + ex.Message);
            }
        }

        public string UpdateCustomer(int id, Customer customer)
        {
            try
            {
                return _customerRepository.UpdateCustomer(id, customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in UpdateCustomer: " + ex.Message);
            }
        }

        public string DeleteCustomer(int id)
        {
            try
            {
                return _customerRepository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in DeleteCustomer: " + ex.Message);
            }
        }
    }
}
