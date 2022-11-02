using BusinessObjects.DAO;
using DataAccessObjects.Entity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Service
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomer();
        Customer GetCustomerById(int? customerId);
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer LoginCustomer(string email, string password);
        Customer GetCustomerByEmail(string email);
    }
    public class CustomerRepository : ICustomerRepository
    {
        public void CreateCustomer(Customer customer)
        => CustomerDAO.Instance.Create(customer);

        public void DeleteCustomer(Customer customer)
        => CustomerDAO.Instance.Remove(customer);

        public Customer GetCustomerByEmail(string email)
        => CustomerDAO.Instance.GetCustomerByEmail(email);

        public Customer GetCustomerById(int? memberId)
        => CustomerDAO.Instance.GetCustomerByID(memberId);

        public IEnumerable<Customer> GetCustomer()
        => CustomerDAO.Instance.GetCustomerList();

        public void UpdateCustomer(Customer customer)
        => CustomerDAO.Instance.Update(customer);

        public Customer LoginCustomer(string email, string password)
        => CustomerDAO.Instance.LoginCustomer(email, password);
    }
}

