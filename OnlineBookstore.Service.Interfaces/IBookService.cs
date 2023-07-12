namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBookService
    {
        void Add(Book book);

        void Edit(Book book);

        void Delete(Book book);

        Book GetBookById(int id);

        IQueryable<Book> GetAllBooksQueryable();

        IEnumerable<Book> GetAllBooks();

        IEnumerable<Book> GetAllBooksByUser(User user);
        IEnumerable<Book> GetAllBooksByUserId(string userId);
        IEnumerable<Book> GetAllBooksByDateDescending();
        IEnumerable<Book> GetAllBooksByDateAscending();
        IEnumerable<Book> GetAllBooksFromToDateByUserId(string userId, DateTime from, DateTime to);
        IEnumerable<Book> GetAllBooksByPriceAscending();
        IEnumerable<Book> GetAllBooksByPriceDescending();
        IEnumerable<Book> GetAllBooksByCountry(string country);
        IEnumerable<Book> GetAllBooksByAuthor(string authorName);
        IEnumerable<Book> GetAllBooksByPublisher(string publisherName);
        IEnumerable<Book> GetTop5PopularBooks();
        IEnumerable<Book> GetTopPopularBooksByBestSellingAuthor(int authorId);

        // IMPORTANT!!!
        IEnumerable<Book> GetAllBooksWithFullRelationalData();
    }
}
