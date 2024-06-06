using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Commands.LoanUpdate
{
    public class LoanUpdateCommandHandler : IRequestHandler<LoanUpdateCommand, int>
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public LoanUpdateCommandHandler(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(LoanUpdateCommand request, CancellationToken cancellationToken)
        {
            var loan = await _dbContext.Loans.SingleOrDefaultAsync(l => l.Id == request.Id);

            if (loan == null) { return 0; }

            loan.Update(request.IdUser, request.IdBook);
            await _dbContext.SaveChangesAsync();

            return loan.Id;
        }
    }
}
