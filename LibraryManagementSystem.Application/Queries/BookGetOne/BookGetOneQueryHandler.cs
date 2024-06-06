using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Application.Queries.BookGetOne
{

    public class BookGetOneQueryHandler : IRequestHandler<BookGetOneQuery, BookViewModel>
    {
        private readonly LibMgmtSysDbContext _dbContext;
        public BookGetOneQueryHandler(LibMgmtSysDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
        }

        public async Task<BookViewModel> Handle(BookGetOneQuery request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == request.Id);

            var bookViewModel = new BookViewModel(book.Title, book.Author, book.PublicationYear);

            return bookViewModel ;
        }
    }
}
