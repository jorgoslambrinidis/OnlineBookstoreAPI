namespace OnlineBookstore.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBaseService<T> where T: class
    {
        IEnumerable<T> GetAll();

        IQueryable<T> GetAllQueryable();

        Task<T> Get(Guid Id);

        Task<T> Get(int id);

        Task<T> Get();

        void Add(T entity);

        void AddRange(List<T> entities);

        void Edit(T entity);

        void Delete(T entity);
    }
}
