using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.LoanCreate
{
    public class LoanCreateCommandHandler : IRequestHandler<LoanCreateCommand, int>
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public LoanCreateCommandHandler(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(LoanCreateCommand request, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == request.IdBook);

            if (book != null && book.Availability == Core.Enums.BookStatus.Available)
            {
                var loan = new Loan(request.IdUser, request.IdBook);
                await _dbContext.Loans.AddAsync(loan);

                book.BookSetUnavailable();
                await _dbContext.SaveChangesAsync();

                return loan.Id;
            }

            return 0;
        }
    }
}
