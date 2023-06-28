namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;
    using System.Collections.Generic;

    public interface IPublisherService
    {
        void Add(Publisher publisher);

        void Edit(Publisher publisher);

        void Delete(Publisher publisher);

        Publisher GetPublisherById(int id);

        Publisher GetPublisherByName(string name);

        Publisher GetPublisherByCountry(string country);

        IEnumerable<Publisher> GetAllPublishers();
    }
}
