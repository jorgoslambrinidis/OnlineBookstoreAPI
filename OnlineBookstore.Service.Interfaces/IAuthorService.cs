namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        void Add(Author author);

        void Edit(Author author);

        void Delete(Author author);

        Author GetAuthorById(int id);

        Author GetAuthorByPopularity(bool popularity);

        IEnumerable<Author> GetAuthors();

        IEnumerable<Author> GetAuthorsByPopularity(bool popularity);
    }
}
