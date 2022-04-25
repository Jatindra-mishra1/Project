using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        [Route("books")]
        public Book[] Get()
        {
            return (new libraryContext()).Books.ToArray();
        }
        [HttpPost]
        [Route("add_book")]
        public Book AddBook(Book _Book)
        {
            var context = new libraryContext();
            context.Books.Add(_Book);
            context.SaveChangesAsync();
            return _Book;
        }
        [HttpDelete]
        [Route("delete_book")]
        public bool DeleteBook(int BookId)
        {
            var context = new libraryContext();
            Book book = context.Books.FirstOrDefault(b=>b.BookId==BookId);
            if (book != null)
                context.Books.Remove(book);
            else
                return false;
            context.SaveChangesAsync();
            return true;
        }
    }
}
