using DataAccessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders;
            try
            {
                var context = new PRN221_DBContext();
                orders = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public IEnumerable<Order> GetFilterBetweenDate(DateTime startDate, DateTime endDate)
        {
            List<Order> orders;
            try
            {
                var context = new PRN221_DBContext();
                orders = context.Orders.Where(o => o.CreateTime >= startDate && o.CreateTime <= endDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders.OrderByDescending(p => p.CreateTime);
        }
        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            List<Order> orders;
            try
            {
                var context = new PRN221_DBContext();
                orders = context.Orders.Where(o => o.CustomerId == customerId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders.OrderByDescending(p => p.CreateTime);
        }
        public Order GetByID(int orderId)
        {
            Order customer;
            try
            {
                var context = new PRN221_DBContext();
                customer = context.Orders.SingleOrDefault(m => m.CustomerId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        public bool Create(Order customer)
        {
            try
            {
                Order p = GetByID(customer.Id);
                if (p == null)
                {
                    var context = new PRN221_DBContext();
                    context.Orders.Add(customer);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Remove(Order customer)
        {
            try
            {
                Order p = GetByID(customer.Id);
                if (p != null)
                {
                    var context = new PRN221_DBContext();
                    context.Orders.Remove(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
