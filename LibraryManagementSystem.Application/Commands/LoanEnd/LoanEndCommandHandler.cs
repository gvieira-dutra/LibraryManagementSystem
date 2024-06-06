using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Commands.LoanEnd
{
    public class LoanEndCommandHandler : IRequestHandler<LoanEndCommand, string>
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public LoanEndCommandHandler(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> Handle(LoanEndCommand request, CancellationToken cancellationToken)
        {

            var loan = _dbContext.Loans
                .Include(l => l.Book)
                .SingleOrDefault(l => l.Id == request.Id);


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

                await _dbContext.SaveChangesAsync();
            }

            return message;
        }
    }
}
