using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryAPI.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string IssuedTo { get; set; }
        public string BookType { get; set; }
    }
}
