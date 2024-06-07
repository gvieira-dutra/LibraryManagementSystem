using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Application.Commands.BookCreateNew
{
    public class BookCreateNewCommandHandler : IRequestHandler<BookCreateNewCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public BookCreateNewCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(BookCreateNewCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Author, request.ISNB, request.PublicationYear);

            await _bookRepository.BookCreateAsync(book);

            return book.Id;
        }
    }
}
