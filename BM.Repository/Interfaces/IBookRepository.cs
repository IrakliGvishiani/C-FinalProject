using BM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BM.Repository.Interfaces
{
    public interface IBookRepository
    {
            IEnumerable<Book> GetAllBooks();
            Book GetBookByName(string name);
            Task<int> AddBookAsync(Book book);
            Task DeleteBookAsync(int id);
    }
}
