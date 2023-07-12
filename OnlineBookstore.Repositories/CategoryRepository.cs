namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public CategoryRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var result = _context.Categories.AsEnumerable();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = _context.Categories.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Category GetCategoryByName(string name)
        {
            var result = _context.Categories.FirstOrDefault(x => x.Name == name);
            return result;
        }
    }
}
