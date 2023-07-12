namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class AuthorRepository : IAuthorRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public AuthorRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Author.Remove(author);
            _context.SaveChanges();
        }

        public void Edit(Author author)
        {
            _context.Author.Update(author);
            _context.SaveChanges();
        }

        public Author GetAuthorById(int id)
        {
            var result = _context.Author.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Author GetAuthorByPopularity(bool popularity)
        {
            var result = _context.Author.Where(x => x.IsPopular == popularity).FirstOrDefault();
            return result;
        }

        public IEnumerable<Author> GetAuthors()
        {
            var result = _context.Author.AsEnumerable();
            return result;
        }

        public IEnumerable<Author> GetAuthorsByPopularity(bool popularity)
        {
            var result = _context.Author.Where(x => x.IsPopular == popularity).AsEnumerable();
            return result;
        }
    }
}
