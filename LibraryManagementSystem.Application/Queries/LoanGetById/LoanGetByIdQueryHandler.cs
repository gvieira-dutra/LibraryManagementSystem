using LibraryManagementSystem.Application.Queries.LoanGetAll;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Queries.LoanGetById
{
    public class LoanGetByIdQueryHandler : IRequestHandler<LoanGetByIdQuery, LoanDetailViewModel>
    {

        private readonly ILoanRepository _loanRepository;

        public LoanGetByIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<LoanDetailViewModel> Handle(LoanGetByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.LoanGetByIdAsync(request.Id);

            if (loan != null)
            {
                loan.LoanCheckLate();

                var loanVM = new LoanDetailViewModel(
                    loan.Id,
                    loan.UserId,
                    loan.BookId,
                    loan.LoanStartDate,
                    loan.LoanCurrStatus.ToString(),
                    loan.Book.Title,
                    loan.User.FullName);

                return loanVM;
            }

            return null;
        }
    }
}
