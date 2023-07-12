namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class ShopCartRepository : IShopCartRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public ShopCartRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(ShopCart shopCart)
        {
            _context.ShopCarts.Add(shopCart);
            _context.SaveChanges();
        }

        public void Delete(ShopCart shopCart)
        {
            _context.ShopCarts.Remove(shopCart);
            _context.SaveChanges();
        }

        public void Edit(ShopCart shopCart)
        {
            _context.ShopCarts.Update(shopCart);
            _context.SaveChanges();
        }

        public IEnumerable<ShopCart> GetAllShopCarts()
        {
            var result = _context.ShopCarts.AsEnumerable();
            return result;
        }

        public ShopCart GetShopCartById(int id)
        {
            var result = _context.ShopCarts.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
