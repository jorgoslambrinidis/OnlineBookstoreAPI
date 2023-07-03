namespace OnlineBookstore.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PublisherRepository : IPublisherRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public PublisherRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public void Delete(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public void Edit(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            var result = _context.Publishers.AsEnumerable();
            return result;
        }

        public Publisher GetPublisherByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public Publisher GetPublisherById(int id)
        {
            throw new NotImplementedException();
        }

        public Publisher GetPublisherByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
