namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public OrderRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Edit(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var result = _context.Orders.AsEnumerable();
            return result;
        }

        public IEnumerable<Order> GetAllOrdersByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
