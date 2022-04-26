using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Exceptions;
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
        public Book AddBook([FromBody]Book _Book)
        {
            var context = new libraryContext();
            context.Books.Add(_Book);
            context.SaveChangesAsync();
            return _Book;
        }
        [HttpDelete]
        [Route("delete_book")]
        public string DeleteBook(int BookId)
        {
            var context = new libraryContext();
            Book book = context.Books.FirstOrDefault(b => b.BookId == BookId);
            try
            {
                if (book != null) {
                    context.Books.Remove(book);
                    context.SaveChangesAsync();
                    return "Success!";
                }
                throw new BookNotFoundException("Book not Present in the Registry");
            }
            catch (BookNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return "Failed!";
            }
        }
        [HttpPut]
        [Route("update_book")]
        public Book UpdateBook(int BookId,[FromBody]Book book)
        {
            var context = new libraryContext();
            try
            {
                if (book != null)
                {
                    Book Matched = context.Books.FirstOrDefault(b => b.BookId == BookId);
                    Matched.BookName = book.BookName;
                    Matched.IssuedTo = book.IssuedTo;
                    Matched.Author = book.Author;
                    Matched.BookType = book.BookType;
                    context.SaveChangesAsync();
                }
                throw new BookNotFoundException("Book is Invalid");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPost]
        [Route("issue_book")]
        public string IssueBook([FromQuery]int BookId,[FromQuery] int Id)
        {
            var context = new libraryContext();
            try
            {
                UserController uc = new UserController();
                var Book=context.Books.Find(BookId);
                int User=-1;

                if (uc.StudentExist(Id))
                {
                    User = context.Students.FirstOrDefault(s => s.StudentId == Id).StudentId;
                }
                else if(uc.TeacherExist(Id))
                {
                    User = context.Teachers.FirstOrDefault(s => s.TeacherId == Id).TeacherId;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                Book.IssuedTo = User.ToString();
                context.SaveChangesAsync();
                return "Success!";
            }
            catch (Exception)
            {
                return "Success!";
            }
        }
        [HttpPost]
        [Route("return_book")]
        public string returnBook([FromQuery] int BookId)
        {
            var context = new libraryContext();
            try
            {
                UserController uc = new UserController();
                var Book = context.Books.Find(BookId);
                Book.IssuedTo = null;
                context.SaveChangesAsync();
                return "Success!";
            }
            catch (Exception)
            {
                return "Success!";
            }
        }
    }
}
