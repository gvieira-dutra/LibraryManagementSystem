using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.LoanUpdate
{
    public class LoanUpdateCommandHandler(ILoanRepository loanRepository, IBookRepository bookRepository) : IRequestHandler<LoanUpdateCommand, int>
    {
        private readonly ILoanRepository _loanRepository = loanRepository;
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<int> Handle(LoanUpdateCommand request, CancellationToken cancellationToken)
        {
            var newBook = await _bookRepository.BookGetOneAsync(request.IdBook);
            var loan = await _loanRepository.LoanGetByIdAsync(request.Id);

            if (loan == null) { return 0; }

            loan.Update(request.IdUser, request.IdBook, newBook);

            await _loanRepository.LoanSaveChangesAsync();

            return loan.Id;
        }
    }
}
