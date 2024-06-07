using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.LoanUpdate
{
    public class LoanUpdateCommandHandler : IRequestHandler<LoanUpdateCommand, int>
    {
        private readonly ILoanRepository _loanRepository;

        public LoanUpdateCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<int> Handle(LoanUpdateCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.LoanGetByIdAsync(request.Id);

            if (loan == null) { return 0; }

            loan.Update(request.IdUser, request.IdBook);
            
            await _loanRepository.LoanSaveChangesAsync();

            return loan.Id;
        }
    }
}
