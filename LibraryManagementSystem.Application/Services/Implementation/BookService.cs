using Dapper;
using LibraryManagementSystem.Application.Services.Interfaces;
using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Enums;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Application.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly LibMgmtSysDbContext _dbContext;
        private readonly string _connectionString;

        public BookService(LibMgmtSysDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("LibraryMgmtSysCs");
        }

        public List<BookViewModel>? BookGetAll(string query)
        {
            var  books = _dbContext.Books.AsQueryable();

            books = books.Where(b => b.Availability != BookStatus.NotInTheSystem);

            if (!string.IsNullOrEmpty(query))
            {
                books = books.Where(b => b.Title.Contains(query));
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

        public void BookDelete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            if (book != null)
            {
                book.BookSetNotInTheSystem();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    var script = "UPDATE Books SET Availability = @availability WHERE Id = @id";

                    sqlConnection.Execute(script, new {availability = book.Availability, id });
                }

            }

        }
    }
}
