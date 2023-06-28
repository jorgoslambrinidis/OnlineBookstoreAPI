namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        void Add(Category category);

        void Edit(Category category);

        void Delete(Category category);

        Category GetCategoryById(int id);

        Category GetCategoryByName(string name);

        IEnumerable<Category> GetAllCategories();
    }
}
