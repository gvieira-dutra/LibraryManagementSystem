using LibraryManagementSystem.Application.Services.Interfaces;
using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Infrastructure.Persistence;

namespace LibraryManagementSystem.Application.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public BookService(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookViewModel>? BookGetAll(string query)
        {
            var books = _dbContext.Books;

            if (!string.IsNullOrEmpty(query))
            {
                books = (List<Book>)books.
                        Where(b => b.Title.Contains(query));
            }

            var booksVM = books.Select(b => new BookViewModel(b.Title, b.Author, b.PublicationYear))
                        .ToList();

            return booksVM ?? null;
        }

        public Book? BookGetOne(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            return book ?? null;
        }
        public int BookCreateNew(BookCreateNewModel newBook)
        {
            var book = new Book(newBook.Title, newBook.Author, newBook.ISNB, newBook.PublicationYear);

            _dbContext.Books.Add(book);

            return book.Id;
        }

        public void BookDelete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            if (book != null)
            {
                book.BookSetNotInTheSystem();
            }

        }
    }
}
