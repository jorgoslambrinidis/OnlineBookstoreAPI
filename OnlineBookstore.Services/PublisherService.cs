namespace OnlineBookstore.Services
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using OnlineBookstore.Service.Interfaces;
    using System.Collections.Generic;

    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void Add(Publisher publisher)
        {
            _publisherRepository.Add(publisher);
        }

        public void Delete(Publisher publisher)
        {
            _publisherRepository.Delete(publisher);
        }

        public void Edit(Publisher publisher)
        {
            _publisherRepository.Edit(publisher);
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            var result = _publisherRepository.GetAllPublishers();
            return result;
        }

        public Publisher GetPublisherByCountry(string country)
        {
            var result = _publisherRepository.GetPublisherByCountry(country);
            return result;
        }

        public Publisher GetPublisherById(int id)
        {
            var result = _publisherRepository.GetPublisherById(id);
            return result;
        }

        public Publisher GetPublisherByName(string name)
        {
            var result = _publisherRepository.GetPublisherByName(name);
            return result;
        }
    }
}
