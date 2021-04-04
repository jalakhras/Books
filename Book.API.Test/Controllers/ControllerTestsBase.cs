using Books.API.Controllers;
using Books.API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace Book.API.Test.Controllers
{
    public class ControllerTestsBase
    {
        public readonly MockRepository mockRepository;
        public readonly Mock<IBooksRepository> mockBooksRepository;
        public ControllerTestsBase()
        {
            mockRepository = new MockRepository(MockBehavior.Loose);
            mockBooksRepository = mockRepository.Create<IBooksRepository>();
        }

        public IEnumerable<Books.API.Entity.Book> GetFakeData()
        {
            var book = new Books.API.Entity.Book
            {
                Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                Title = "The Winds of Winter",
                Description = "The book that seems impossible to write."
            };
            var list = new List<Books.API.Entity.Book>
            {
                book
            };
            return list;


        }
        public async Task<IEnumerable<Books.API.Entity.Book>> GetFakeDataAsyn()
        {
            var t = new Books.API.Entity.Book
            {
                Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                Title = "The Winds of Winter",
                Description = "The book that seems impossible to write."
            };
            var list = new List<Books.API.Entity.Book>();
            list.Add(t);
            return await Task.FromResult(list);


        }
        public async Task<Books.API.Entity.Book> GetOneFakeDataAsyn()
        {
            var book = new Books.API.Entity.Book
            {
                Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                Title = "The Winds of Winter",
                Description = "The book that seems impossible to write."
            };

            return await Task.FromResult(book);


        }
    }
}
