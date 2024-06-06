using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Queries.LoanGetAll
{
    public class LoanGetAllQueryHandler : IRequestHandler<LoanGetAllQuery, List<LoanViewModel>>
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public LoanGetAllQueryHandler(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LoanViewModel>> Handle(LoanGetAllQuery request, CancellationToken cancellationToken)
        {
            var loans = await _dbContext.Loans
           .Where(l => l.LoanCurrStatus != Core.Enums.LoanStatus.Returned)
           .Include(l => l.Book)
           .Include(l => l.User)
           .ToListAsync();

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
