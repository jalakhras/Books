using Books.API.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.API.Services
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetBooks();
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Book>> GetBooksAsync(IEnumerable<Guid> booksIds);

        Task<Book> GetBookByIdAsync(Guid id);
        void AddBook(Book bookToAdd);
        Task<bool> SaveChangesAsync();
    }
}