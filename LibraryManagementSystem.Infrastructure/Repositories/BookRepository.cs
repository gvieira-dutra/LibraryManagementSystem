using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class BookRepository(LibMgmtSysDbContext dbContext,
                              IConfiguration config) : IBookRepository
    {
        private readonly LibMgmtSysDbContext _dbContext = dbContext;
        private readonly string _connectionString = config.GetConnectionString("LibraryMgmtSysCs");

        //public BookRepository(LibMgmtSysDbContext dbContext, 
        //                      IConfiguration config)
        //{
        //    _dbContext = dbContext;
        //    _connectionString = config.GetConnectionString("LibraryMgmtSysCs");
        //}

        public async Task<List<Book>> BookGetAllAsync(string query)
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> BookGetOneAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> BookCreateAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book.Id;
        }


        public async Task BookDeleteAsync(Book book)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Books SET Availability = @availability WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { availability = book.Availability, book.Id });
            }
        }
    }
}
