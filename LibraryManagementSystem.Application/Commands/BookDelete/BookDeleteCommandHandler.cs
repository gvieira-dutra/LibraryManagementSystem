using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.BookDelete
{

    public class BookDeleteCommandHandler(IBookRepository bookRepository) : IRequestHandler<BookDeleteCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<Unit> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
        {            
            var book = await _bookRepository.BookGetOneAsync(request.Id);

                if (book != null)
                {
                    book.BookSetNotInTheSystem();

                    await _bookRepository.BookDeleteAsync(book);
                }

            return Unit.Value;
        }

    }
}
