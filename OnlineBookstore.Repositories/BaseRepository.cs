namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Data;
    using OnlineBookstore.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private readonly OnlineBookstoreDbContext _context;
        private readonly DbSet<T> _entities;

        public BaseRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(List<T> entities)
        {
            if (entities == null) { throw new ArgumentNullException("entities"); }
            _entities.AddRange(entities);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            _entities.Update(entity);
            _context.SaveChanges();
        }

        public async Task<T> Get(Guid Id)
        {
            var result = await _entities.FindAsync(Id);
            return result;
        }

        public async Task<T> Get()
        {
            var id = Guid.NewGuid();
            var result = await _entities.FindAsync();
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            var result = _entities.AsEnumerable();
            return result;
        }

        public IQueryable<T> GetAllQueryable()
        {
            var result = _entities.AsQueryable();
            return result;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
