using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.application.Service.Interface;
using Test.DataLayer.Entitis.product;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Constructor

        private readonly IBookService _bookService;
        private object _bookRepository;

        public ProductController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion
        #region book

        #region Get List Book
        [HttpGet("AllBooks")]
        public async Task<IActionResult> GetAllBookAsync() 
        {
            
            return Ok(await _bookService.GetAllBookAsync());
        }

        [HttpGet("book/{BookId:long}")]
        public async Task<IActionResult> GetBookById(long BookId)
        {
            var result = await _bookService.GetBookByIdAsync(BookId);
            if (result == null) 
            {
                return NotFound();
            }
            return Ok(result);
        }
        #endregion
        #region AddBook

        // Api/Product/add-Book
        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook(Book book)
        {
            Book _book = new Book();
            if (book != null)
            {

                _book= await _bookService.AddBook(book);

            }

                return Ok(_book);
           
        }
        #endregion
        #region Edit
        [HttpPost("edit-book/{bookId:long}")]
        public async Task<IActionResult> EditBook(long bookId , Book book)
        {
            var result= await _bookService.EditBookAsync(bookId, book);
            if (!result)
                return BadRequest();
            else
            {
                Book b = new Book();
                b = await _bookService.GetBookByIdAsync(bookId);

                return Ok(b);
            }



            return NoContent();
        }
        #endregion
        #region Delete

        [HttpDelete("virtual-delete/{bookId:long}")]
        public async Task<IActionResult> VirtualDelete(long bookId)
        {
            var result = await _bookService.VirtualDeleteAsync(bookId);

            if(!result)
                return BadRequest();



            return NoContent();
        }

        #endregion
        #region

        [HttpDelete("real-delete/{bookId:long}")]
        public async Task<IActionResult> RealDelete(long bookId)
        {
            var result = await _bookService.RealDeleteAsync(bookId);

            if (!result)
                return BadRequest();



            return NoContent();
        }
        #endregion
        #endregion
    }
}
