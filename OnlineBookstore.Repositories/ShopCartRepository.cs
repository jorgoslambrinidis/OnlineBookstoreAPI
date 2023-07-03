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

    public class ShopCartRepository : IShopCartRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public ShopCartRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(ShopCart shopCart)
        {
            throw new NotImplementedException();
        }

        public void Delete(ShopCart shopCart)
        {
            throw new NotImplementedException();
        }

        public void Edit(ShopCart shopCart)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShopCart> GetAllShopCarts()
        {
            var result = _context.ShopCarts.AsEnumerable();
            return result;
        }

        public ShopCart GetShopCartById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
