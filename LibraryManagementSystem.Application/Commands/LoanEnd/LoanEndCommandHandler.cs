using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.LoanEnd
{
    public class LoanEndCommandHandler : IRequestHandler<LoanEndCommand, string>
    {
        private readonly ILoanRepository _loanRepository;

        public LoanEndCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<string> Handle(LoanEndCommand request, CancellationToken cancellationToken)
        {

            var loan = await _loanRepository.LoanGetByIdAsync(request.Id);


            var message = "";

            if (loan != null)
            {
                loan.LoanCheckLate();

                if (loan.LoanCurrStatus == Core.Enums.LoanStatus.Late)
                {
                    message += "This book is late!";
                }
                else
                {
                    message += "Thank you for returning on time!";
                }

                loan.LoanSetReturned();
                loan.Book.BookSetAvailable();

                await _loanRepository.LoanSaveChangesAsync();
            }
            return message;
        }
    }
}
