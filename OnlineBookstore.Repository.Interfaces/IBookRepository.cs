namespace OnlineBookstore.Repository.Interfaces
{
    using OnlineBookstore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBookRepository
    {
        void Add(Book book);

        void Edit(Book book);

        void Delete(Book book);

        Book GetBookById(int id);

        IEnumerable<Book> GetAllBooks();
    }
}
