using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.LoanCreate
{
    public class LoanCreateCommandHandler : IRequestHandler<LoanCreateCommand, string>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public LoanCreateCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<string> Handle(LoanCreateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.UserGetByIdAsync(request.IdUser);
            var book = await _bookRepository.BookGetOneAsync(request.IdBook);

            if (book != null &&
                user != null &&
                book.Availability == Core.Enums.BookStatus.Available)
            {
                var loan = new Loan(request.IdUser, request.IdBook);

                await _loanRepository.LoanCreateAsync(loan);
                
                book.BookSetUnavailable();
                
                await _loanRepository.LoanSaveChangesAsync();

                return $"Enjoy your book! Loan id( {loan.Id} )";
            }

            return "Something went wrong, we could not create this loan.";
        }
    }
}
