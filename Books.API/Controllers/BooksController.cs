using AutoMapper;
using Books.API.Filters;
using Books.API.Models;
using Books.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository ??
                throw new ArgumentNullException(nameof(booksRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

          
        }

        [HttpGet]
        [BookResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _booksRepository.GetBooksAsync();
            return Ok(bookEntities);
        }

        [HttpGet]
        [Route("{id}",Name = "GetBook")]
        [BookResultFilter]
        [BookWithCoversResultFilter ]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var bookEntity = await _booksRepository.GetBookByIdAsync(id);
            if (bookEntity == null)
            {
                return NotFound();
            }
            var bookCovers = await _booksRepository.GetBookCoversAsync(id);
            //var propertyBag = new Tuple<Entity.Book, IEnumerable<ExternalModels.BookCover>>
            //    (bookEntity, bookCovers);
            //(Entity.Book book, IEnumerable<ExternalModels.BookCover> bookCovers)
            //    propertyBag = (bookEntity, bookCovers);
            return Ok((bookEntity,  bookCovers));
        }

        [HttpPost]
        [BookResultFilter]
        public async Task<IActionResult> CreateBook(BookForCreation bookForCreation)
        {
            var bookEntity = _mapper.Map<Entity.Book>(bookForCreation);

            _booksRepository.AddBook(bookEntity);

            await _booksRepository.SaveChangesAsync();

            // Fetch (refetch) the book from the data store, including the author
            await _booksRepository.GetBookByIdAsync(bookEntity.Id);

            return CreatedAtRoute(
                "GetBook",
                 new { id = bookEntity.Id },
                 bookEntity);
        }
    }
}