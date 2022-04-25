namespace LibraryAPI.Models
{
    public partial class EBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string IssuedTo { get; set; }
    }
}
