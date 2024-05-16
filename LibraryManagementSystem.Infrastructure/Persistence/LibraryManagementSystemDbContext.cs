using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Persistence
{
    public class LibraryManagementSystemDbContext
    {
        public LibraryManagementSystemDbContext()
        {
            Books = new List<Book>
            {
                new Book("Lord of the Rings", "Mr Token", "11111", 2000),
                new Book("Harry Potter", "JK Rolling", "22222", 2001),
                new Book("Da Vinci Code", "Tom Hanks", "33333", 2004)
            };

            Users = new List<User>
            {
                new User("RobertS", "rs@mail.com"),
                new User("AdrianaD", "ad@mail.com"),
                new User("GleisonV", "gv@mail.com")
            };

        }

        public List<Book> Books { get; set; }
        public List<Loan> Loans { get; set; }
        public List<User> Users { get; set; }
    }
}
