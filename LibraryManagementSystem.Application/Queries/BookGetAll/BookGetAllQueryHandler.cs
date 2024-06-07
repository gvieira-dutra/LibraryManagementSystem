using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Enums;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Queries.BookGetAll
{
    public class BookGetAllQueryHandler : IRequestHandler<BookGetAllQuery, List<BookViewModel>>
    {
        private readonly IBookRepository _bookRepository;

        public BookGetAllQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookViewModel>> Handle(BookGetAllQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.BookGetAllAsync(request.query);

            books = books.Where(b => b.Availability != BookStatus.NotInTheSystem).ToList();

            if (!string.IsNullOrEmpty(request.query))
            {
                books = books.Where(b => b.Title.Contains(request.query)).ToList();
            }

            var booksVM = books.Select(b => new BookViewModel(b.Title, b.Author, b.PublicationYear)).ToList();

            return booksVM;
        }
    }
}
