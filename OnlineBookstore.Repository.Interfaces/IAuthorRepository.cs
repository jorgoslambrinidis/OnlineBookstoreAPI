namespace OnlineBookstore.Repository.Interfaces
{
    using OnlineBookstore.Entities;
    using System.Collections.Generic;

    public interface IAuthorRepository
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
