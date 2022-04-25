using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryAPI.Models
{
    public partial class Admin
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
