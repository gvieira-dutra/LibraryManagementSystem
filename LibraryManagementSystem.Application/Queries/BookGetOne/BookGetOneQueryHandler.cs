using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.BookGetOne
{

    public class BookGetOneQueryHandler(IBookRepository bookRepository) : IRequestHandler<BookGetOneQuery, BookViewModel>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<BookViewModel> Handle(BookGetOneQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.BookGetOneAsync(request.Id);

            var bookViewModel = new BookViewModel(book.Title, book.Author, book.PublicationYear);

            return bookViewModel ;
        }
    }
}
