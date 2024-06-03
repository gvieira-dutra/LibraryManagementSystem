using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Application.Commands.BookCreateNew
{
    public class BookCreateNewCommandHandler : IRequestHandler<BookCreateNewCommand, int>
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public BookCreateNewCommandHandler(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(BookCreateNewCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Author, request.ISNB, request.PublicationYear);

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book.Id;
        }
    }
}
