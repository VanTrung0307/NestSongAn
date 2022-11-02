using BusinessObjects.DAO;
using DataAccessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Service
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> FilterBetweenDate(DateTime startDate, DateTime endDate);
        IEnumerable<Order> GetOrdersByCustomerId(int customerId);
        Order GetOrderById(int orderId);
        bool CreatOrder(Order order);
        void DeleteOrder(Order order);

    }
    public class OderRepository : IOrderRepository
    {
        public bool CreatOrder(Order order)
        => OrderDAO.Instance.Create(order);

        public void DeleteOrder(Order order)
        => OrderDAO.Instance.Remove(order);

        public Order GetOrderById(int orderId)
        => OrderDAO.Instance.GetByID(orderId);

        public IEnumerable<Order> GetOrders()
        => OrderDAO.Instance.GetOrders();

        public IEnumerable<Order> FilterBetweenDate(DateTime startDate, DateTime endDate)
        => OrderDAO.Instance.GetFilterBetweenDate(startDate, endDate);

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        => OrderDAO.Instance.GetOrdersByCustomerId(customerId);
    }
}
