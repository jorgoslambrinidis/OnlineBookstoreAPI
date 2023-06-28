namespace OnlineBookstore.Services
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public void Edit(Book book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByAuthor(string authorName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByCountry()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByDateAscending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByDateDescending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByPriceAscending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByPriceDescending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByPublisher(string publisherName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByUser()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksFromToDateByUserId(string userId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> GetAllBooksQueryable()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksWithFullRelationalData()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetTop5PopularBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetTopPopularBooksByBestSellingAuthor()
        {
            throw new NotImplementedException();
        }
    }
}
