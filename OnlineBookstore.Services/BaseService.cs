namespace OnlineBookstore.Services
{
    using OnlineBookstore.Repository.Interfaces;
    using OnlineBookstore.Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Add(T entity)
        {
            _baseRepository.Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            _baseRepository.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _baseRepository.Delete(entity);
        }

        public void Edit(T entity)
        {
            _baseRepository.Edit(entity);
        }

        public async Task<T> Get(Guid Id)
        {
            var result = await _baseRepository.Get(Id);
            return result;
        }

        public async Task<T> Get()
        {
            var result = await _baseRepository.Get();
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            var result = _baseRepository.GetAll();
            return result;
        }

        public IQueryable<T> GetAllQueryable()
        {
            var result = _baseRepository.GetAllQueryable();
            return result;
        }
    }
}
