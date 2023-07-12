namespace OnlineBookstore.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BookRepository : IBookRepository
    {
        private readonly OnlineBookstoreDbContext _context;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(OnlineBookstoreDbContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.BookCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.BookEditNotFound, ex);
            }
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void Edit(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            // example with swl raw
            // var result = _context.Books.FromSqlRaw("SELECT * FROM Books);

            var result = _context.Books.AsEnumerable();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByAuthor(string authorName)
        {
            // example with swl raw
            // var result = _context.Books.FromSqlRaw("SELECT * FROM Books WHERE AuthorName = " + authorName);

            var result = _context.Books.Where(b => b.AuthorName == authorName);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByCountry(string country)
        {
            // example with swl raw
            // var result = _context.Books.FromSqlRaw("SELECT * FROM Books WHERE Country = " + country);
            
            var result = _context.Books.AsEnumerable().Where(x => x.Country == country);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByDateAscending()
        {
            // example with swl raw
            // var result = _context.Books.FromSqlRaw("SELECT * FROM Books ORDER BY YearOfIssue").AsEnumerable(); 

            var result = _context.Books.AsEnumerable().OrderBy(x => x.YearOfIssue);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByDateDescending()
        {
            // example with swl raw
            // var result = _context.Books.FromSqlRaw("SELECT * FROM Books ORDER BY YearOfIssue DESC").AsEnumerable(); 

            var result = _context.Books.AsEnumerable().OrderByDescending(x => x.YearOfIssue);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPriceAscending()
        {
            var result = _context.Books.AsEnumerable().OrderBy(x => x.Price);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPriceDescending()
        {
            var result = _context.Books.AsEnumerable().OrderByDescending(x => x.Price);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPublisher(string publisherName)
        {
            var result = _context.Books.AsEnumerable().Where(x => x.PublisherName == publisherName);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByUser(User user)
        {
            var result = _context.Books.AsEnumerable().Where(x => x.UserId == user.Id.ToString());
            return result;
        }

        public IEnumerable<Book> GetAllBooksByUserId(string userId)
        {
            var result = _context.Books.AsEnumerable().Where(x => x.UserId == userId);
            return result;
        }

        public IEnumerable<Book> GetAllBooksFromToDateByUserId(string userId, DateTime from, DateTime to)
        {
            var result = _context.Books.Where(b => b.YearOfIssue >= from && b.YearOfIssue <= to).AsEnumerable();
            return result;
        }

        public IQueryable<Book> GetAllBooksQueryable()
        {
            var result = _context.Books.AsQueryable();
            return result;
        }

        public IEnumerable<Book> GetAllBooksWithFullRelationalData()
        {
            var result = _context.Books.Include(a => a.Author).Include(c => c.Category).Include(p => p.Publisher).AsEnumerable();
            return result;
        }

        public Book GetBookById(int id)
        {
            var result = _context.Books.FirstOrDefault(b => b.Id == id);
            return result;
        }

        public IEnumerable<Book> GetTop5PopularBooks()
        {
            var result = _context.Books.AsEnumerable().OrderByDescending(x => x.SoldItems).Take(5);
            return result;
        }

        public IEnumerable<Book> GetTopPopularBooksByBestSellingAuthor(int authorId)
        {
            var result = _context.Books.AsEnumerable().Where(x => x.AuthorId == authorId).Take(5);
            return result;
        }
    }
}
