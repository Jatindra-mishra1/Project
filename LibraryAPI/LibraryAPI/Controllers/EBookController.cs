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
    public class EBookController : ControllerBase
    {
        [HttpPost]
        public EBook AddEBook(EBook Ebook)
        {
            Book _Book = new Book();
            _Book.BookId = Ebook.BookId;
            _Book.BookName = Ebook.BookName;
            _Book.Author = Ebook.Author;
            _Book.IssuedTo = Ebook.IssuedTo;
            _Book.BookType = "E-Book";
            libraryContext context = new libraryContext();
            context.Books.Add(_Book);
            context.SaveChangesAsync();
            return Ebook;
        }
    }
}
