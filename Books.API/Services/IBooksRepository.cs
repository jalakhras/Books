using Books.API.Entity;
using Books.API.ExternalModels;
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

        Task<BookCover> GetBookCoverAsync(string coverId);
        Task<IEnumerable<BookCover>> GetBookCoversAsync(Guid bookId);


        Task<bool> SaveChangesAsync();
    }
}