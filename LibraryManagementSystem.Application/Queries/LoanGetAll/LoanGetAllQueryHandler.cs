using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Queries.LoanGetAll
{
    public class LoanGetAllQueryHandler : IRequestHandler<LoanGetAllQuery, List<LoanViewModel>>
    {
        private readonly ILoanRepository _loanRepository;

        public LoanGetAllQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<List<LoanViewModel>> Handle(LoanGetAllQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.LoanGetAllAsync();

            if (loans == null) return null;

            var loansVM = loans.Select(l => new LoanViewModel(
               l.Id,
               l.UserId,
               l.BookId,
               l.Book.Title))
              .ToList();

            return loansVM;
        }
    }
}
