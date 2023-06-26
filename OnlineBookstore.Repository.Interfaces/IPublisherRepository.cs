namespace OnlineBookstore.Repository.Interfaces
{
    using OnlineBookstore.Entities;
    using System.Collections.Generic;

    public interface IPublisherRepository
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
