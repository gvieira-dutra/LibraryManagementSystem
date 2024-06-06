using LibraryManagementSystem.Application.Queries.LoanGetAll;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Queries.LoanGetById
{
    public class LoanGetByIdQueryHandler : IRequestHandler<LoanGetByIdQuery, LoanDetailViewModel>
    {

        private readonly LibMgmtSysDbContext _dbContext;

        public LoanGetByIdQueryHandler(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoanDetailViewModel> Handle(LoanGetByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _dbContext.Loans
           .Include(l => l.Book)
           .Include(l => l.User)
           .SingleOrDefaultAsync(l => l.Id == request.Id);

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
