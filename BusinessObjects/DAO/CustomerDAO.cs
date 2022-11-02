using DataAccessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace BusinessObjects.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();
        private CustomerDAO() { }
        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Customer> GetCustomerList()
        {
            List<Customer> customer;
            try
            {
                var context = new PRN221_DBContext();
                customer = context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        public Customer LoginCustomer(string email, string password)
        {
            var context = new PRN221_DBContext();


            Customer customer = context.Customers.Include(cus => cus.Account).Where(cus => cus.Account.Email.Equals(email.ToLower()) && cus.Account.Password.Equals(password.ToLower())).FirstOrDefault();
            return customer;
        }
        public Customer GetCustomerByID(int? customerId)
        {
            if (customerId == null)
                return null;
            Customer customer;
            try
            {
                var context = new PRN221_DBContext();
                customer = context.Customers.SingleOrDefault(m => m.AccountId == customerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        public Customer GetCustomerByEmail(String email)
        {
            Customer customer;
            try
            {
                var context = new PRN221_DBContext();
                customer = context.Customers.SingleOrDefault(m => m.Email == email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return customer;
        }
        public void Create(Customer customer)
        {
            try
            {
                Customer p = GetCustomerByID(customer.Id);
                if (p == null)
                {
                    var context = new PRN221_DBContext();
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Customer customer)
        {
            try
            {
                Customer p = GetCustomerByID(customer.Id);
                if (p != null)
                {
                    var context = new PRN221_DBContext();
                    context.Entry<Customer>(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(Customer customer)
        {
            try
            {
                Customer p = GetCustomerByID(customer.Id);
                if (p != null)
                {
                    var context = new PRN221_DBContext();
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
