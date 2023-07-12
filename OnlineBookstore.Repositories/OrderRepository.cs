namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public OrderRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = GetOrderById(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void DeleteByUserId(string userId)
        {
            var order = _context.Orders.Where(o => o.UserId == userId).FirstOrDefault();
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void Edit(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var result = _context.Orders.AsEnumerable();
            return result;
        }

        public IEnumerable<Order> GetAllOrdersByUserId(string userId)
        {
            var result = _context.Orders.Where(o => o.UserId == userId).AsEnumerable();
            return result;
        }

        public Order GetOrderById(int id)
        {
            var result = _context.Orders.FirstOrDefault(o => o.Id == id);
            return result;
        }

        public Order GetOrderByUserId(string userId)
        {
            var result = _context.Orders.Where(o => o.UserId == userId).FirstOrDefault();
            return result;
        }
    }
}
