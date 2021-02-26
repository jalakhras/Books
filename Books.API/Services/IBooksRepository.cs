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

        Task<Book> GetBookAsync(Guid id);
    }
}