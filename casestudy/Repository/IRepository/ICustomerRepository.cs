using CaseStudy_Quitq.Models;

namespace CaseStudy_Quitq.Repository.IRepository
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public List<Customer> GetCustomerByName(string name);
        //public List<Customer> GetCustomerByEmail(string email);
        public string AddCustomer(Customer customer);
        public string UpdateCustomer(int id, Customer customer);
        public string DeleteCustomer(int id);
    }
}
