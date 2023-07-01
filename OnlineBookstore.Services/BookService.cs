namespace OnlineBookstore.Services
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using OnlineBookstore.Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

        public void Delete(Book book)
        {
            _bookRepository.Delete(book);
        }

        public void Edit(Book book)
        {
            _bookRepository.Edit(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var result = _bookRepository.GetAllBooks();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByAuthor(string authorName)
        {
            var result = _bookRepository.GetAllBooksByAuthor(authorName);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByCountry()
        {
            var result = _bookRepository.GetAllBooksByCountry();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByDateAscending()
        {
            var result = _bookRepository.GetAllBooksByDateAscending();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByDateDescending()
        {
            var result = _bookRepository.GetAllBooksByDateDescending();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPriceAscending()
        {
            var result = _bookRepository.GetAllBooksByPriceAscending();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPriceDescending()
        {
            var result = _bookRepository.GetAllBooksByPriceDescending();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPublisher(string publisherName)
        {
            var result = _bookRepository.GetAllBooksByPublisher(publisherName);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByUser()
        {
            var result = _bookRepository.GetAllBooksByUser();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByUserId(string userId)
        {
            var result = _bookRepository.GetAllBooksByUserId(userId);
            return result;
        }

        public IEnumerable<Book> GetAllBooksFromToDateByUserId(string userId, DateTime from, DateTime to)
        {
            var result = _bookRepository.GetAllBooksFromToDateByUserId(userId, from, to);
            return result;
        }

        public IQueryable<Book> GetAllBooksQueryable()
        {
            var result = _bookRepository.GetAllBooksQueryable();
            return result;
        }

        public IEnumerable<Book> GetAllBooksWithFullRelationalData()
        {
            var result = _bookRepository.GetAllBooksWithFullRelationalData();
            return result;
        }

        public Book GetBookById(int id)
        {
            var result = _bookRepository.GetBookById(id);
            return result;
        }

        public IEnumerable<Book> GetTop5PopularBooks()
        {
            var result = _bookRepository.GetTop5PopularBooks();
            return result;
        }

        public IEnumerable<Book> GetTopPopularBooksByBestSellingAuthor()
        {
            var result = _bookRepository.GetTopPopularBooksByBestSellingAuthor();
            return result;
        }
    }
}
