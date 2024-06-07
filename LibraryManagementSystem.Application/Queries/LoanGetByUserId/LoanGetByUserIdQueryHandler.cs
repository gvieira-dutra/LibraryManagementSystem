using LibraryManagementSystem.Application.Queries.LoanGetAll;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Queries.LoanGetByUserId
{
    public class LoanGetByUserIdQueryHandler : IRequestHandler<LoanGetByUserIdQuery, List<LoanDetailViewModel>>
    {
        private readonly ILoanRepository _loanRepository;

        public LoanGetByUserIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<List<LoanDetailViewModel>> Handle(LoanGetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.LoanGetByUserIdAsync(request.Id);

            if (loans.Any())
            {

                foreach (var l in loans)
                {
                    l.LoanCheckLate();
                }

                var loansVM = loans.Select(l => new LoanDetailViewModel(
                   l.Id,
                   l.UserId,
                   l.BookId,
                   l.LoanStartDate,
                   l.LoanCurrStatus.ToString(),
                   l.Book.Title,
                   l.User.FullName))
                   .ToList();

                return loansVM;
            }
            return null;
        }
    }
}
