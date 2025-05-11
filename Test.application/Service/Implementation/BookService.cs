using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.application.Service.Interface;
using Test.DataLayer.Entitis.product;
using Test.DataLayer.Repository;

namespace Test.application.Service.Implementation
{
    
    public class BookService : IBookService
    {
        #region constructor

        private readonly IGenericRepository<Book> _bookRepository;
        public BookService(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        #endregion
        async Task<List<Book>> IBookService.GetAllBookAsync()
        {

            return  _bookRepository.GetAll().ToList();
        }

        public async Task<Book> GetBookByIdAsync(long id)
        {
            var result = await _bookRepository.GetAll().AsQueryable().SingleOrDefaultAsync(s => s.Id == id);
            if (result == null)
            {
                return null;

            }
            return result;
        }

        public async Task<Book> AddBook(Book book)
        {
            if(book != null)
            {

                await _bookRepository.AddEntity(book);
                await _bookRepository.SaveChange();
            }
            return book;
           
        }

 

        public async Task<bool> EditBookAsync(long bookId, Book book)
        {
            var result = await _bookRepository.GetAll().AsQueryable().SingleOrDefaultAsync(s => s.Id ==bookId);
            if (result == null)
                return false;

            result.Title = book.Title;
            result.Description = book.Description;
            result.Price = book.Price;
            result.Author = book.Author;
            result.Publisher = book.Publisher;
            result.CoverType = book.CoverType;
            result.Subject = book.Subject;
            result.NumberOfPages = book.NumberOfPages;
            result.Shabk= book.Shabk;
            result.Translator = book.Translator;

            _bookRepository.EditEntity(result);
            await _bookRepository.SaveChange();
            return true;
        }

        #region virtualDelete
        public async Task<bool> VirtualDeleteAsync(long bookId)
        {
            var book = await _bookRepository.GetEntityById(bookId);
                
                if (book != null)
                {

                _bookRepository.DeleteEntity(book);
                await _bookRepository.SaveChange();
                return true;
                }
                
            return false;
        }
        #endregion
        #region Real Delete


        public async Task<bool> RealDeleteAsync(long bookId)
        {
            var book = await _bookRepository.GetEntityById(bookId);

            if (book != null)
            {

                await _bookRepository.DeletePermenant(bookId);
                await _bookRepository.SaveChange();
                return true;
            }
            return false;

        }
        #endregion

    }
}
