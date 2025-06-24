using CaseStudy_Quitq.Contexts;
using CaseStudy_Quitq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy_Quitq.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string PlaceOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    order.OrderDate = DateTime.UtcNow;
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    return "Order placed successfully.";
                }
                else
                {
                    return "Order details are invalid.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in PlaceOrder: " + ex.Message);
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                var orders = _context.Orders.ToList();
                if (orders.Count > 0)
                    return orders;
                else
                    return new List<Order>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllOrders: " + ex.Message);
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
                return order ?? null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetOrderById: " + ex.Message);
            }
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            try
            {
                var orders = _context.Orders.Where(o => o.CustomerId == customerId).ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetOrdersByCustomerId: " + ex.Message);
            }
        }

        public List<Order> GetOrdersBySellerId(int sellerId)
        {
            try
            {
                var orders = _context.Orders.Where(o => o.SellerId == sellerId).ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetOrdersBySellerId: " + ex.Message);
            }
        }

        public List<Order> GetOrdersByProductId(int productid)
        {
            try
            {
                var orders = _context.Orders.Where(o => o.ProductId == productid).ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetOrdersBySellerId: " + ex.Message);
            }
        }

        public string CancelOrder(int id)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                    return $"Order with ID {id} cancelled successfully.";
                }
                else
                {
                    return $"Order with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CancelOrder: " + ex.Message);
            }
        }

        public int GetTotalOrderCount()
        {
            try
            {
                return _context.Orders.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalOrderCount: " + ex.Message);
            }
        }
            public Order UpdateOrderStatus(int orderId, OrderStatus newStatus)
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                    return null;

                order.Status = newStatus;
                _context.SaveChanges();
                return order;
            }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
