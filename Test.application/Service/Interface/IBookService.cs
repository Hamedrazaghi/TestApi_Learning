using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataLayer.Entitis.product;

namespace Test.application.Service.Interface
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBookAsync();
        Task<Book> GetBookByIdAsync(long id);
        Task<Book> AddBook(Book book);
        Task<bool> EditBookAsync(long bookId ,Book book);
        Task<bool> VirtualDeleteAsync(long bookId);
        Task<bool> RealDeleteAsync(long bookId);

    }
}
