namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class PublisherRepository : IPublisherRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public PublisherRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void Delete(Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }

        public void Edit(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            _context.SaveChanges();
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            var result = _context.Publishers.AsEnumerable();
            return result;
        }

        public Publisher GetPublisherByCountry(string country)
        {
            var result = _context.Publishers.FirstOrDefault(x => x.Country == country);
            return result;
        }

        public Publisher GetPublisherById(int id)
        {
            var result = _context.Publishers.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Publisher GetPublisherByName(string name)
        {
            var result = _context.Publishers.FirstOrDefault(x => x.Name == name);
            return result;
        }
    }
}
