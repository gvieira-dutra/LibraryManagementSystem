using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Enums;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryManagementSystem.Application.Queries.BookGetAll
{
    public class BookGetAllQueryHandler : IRequestHandler<BookGetAllQuery, List<BookViewModel>>
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public BookGetAllQueryHandler(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookViewModel>> Handle(BookGetAllQuery request, CancellationToken cancellationToken)
        {
            var books = _dbContext.Books.AsQueryable();

            books = books.Where(b => b.Availability != BookStatus.NotInTheSystem);

            if (!string.IsNullOrEmpty(request.query))
            {
                books = books.Where(b => b.Title.Contains(request.query));
            }

            var booksVM = await books.Select(b => new BookViewModel(b.Title, b.Author, b.PublicationYear))
                        .ToListAsync();

            return booksVM;
        }
    }
}
