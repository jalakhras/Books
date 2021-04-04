using Books.API.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Book.API.Test.Controllers
{
    public class BooksControllerTests : ControllerTestsBase
    {
        private BooksController CreateBooksController()
        {
            mockBooksRepository.Setup(x => x.GetBooks()).Returns(GetFakeData());

            mockBooksRepository.Setup(x => x.GetBooksAsync()).Returns(GetFakeDataAsyn());
            return new BooksController(mockBooksRepository.Object);
        }

        [Fact]
        public async Task GetBooks_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var booksController = this.CreateBooksController();

            // Act
            var result = await booksController.GetBooks();

            // Assert
            Assert.NotNull(result);
            //this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetBook_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var booksController = CreateBooksController();
            Guid id = default;
            // Act
            mockBooksRepository.Setup(x => x.GetBookByIdAsync(id)).Returns(GetOneFakeDataAsyn());

            var result = await booksController.GetBookById(id);

            // Assert
            Assert.NotNull(result);

            //this.mockRepository.VerifyAll();
        }
    }
}