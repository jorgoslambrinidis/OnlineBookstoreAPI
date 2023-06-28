namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        void Add(Order order);

        void Edit(Order order);

        void Delete(Order order);

        void Delete(int id);

        void DeleteByUserId(string userId);


        Order GetOrderById(int id);

        Order GetOrderByUserId(string userId);

        IEnumerable<Order> GetAllOrders();

        IEnumerable<Order> GetAllOrdersByUserId(string userId);
    }
}
