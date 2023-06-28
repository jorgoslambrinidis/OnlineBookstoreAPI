namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AuthorRepository : IAuthorRepository
    {
        public void Add(Author author)
        {
            throw new NotImplementedException();
        }

        public void Delete(Author author)
        {
            throw new NotImplementedException();
        }

        public void Edit(Author author)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorByPopularity(bool popularity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAuthorsByPopularity(bool popularity)
        {
            throw new NotImplementedException();
        }
    }
}
