using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;



namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public LoanRepository(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Loan>> LoanGetAllAsync()
        {
            return await _dbContext.Loans
           .Where(l => l.LoanCurrStatus != Core.Enums.LoanStatus.Returned)
           .Include(l => l.Book)
           .Include(l => l.User)
           .ToListAsync();
        }
    
        public async Task<Loan> LoanGetByIdAsync(int id)
        {
            return await _dbContext.Loans
           .Include(l => l.Book)
           .Include(l => l.User)
           .SingleOrDefaultAsync(l => l.Id == id);
        }
 
        public async Task<List<Loan>> LoanGetByUserIdAsync(int id)
        {
            return await _dbContext.Loans
                .Where(l => l.UserId == id)
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToListAsync();
        }

        public async Task<int> LoanCreateAsync(Loan loan)
        {
            await _dbContext.Loans.AddAsync(loan);

            return loan.Id;
        }

        public async Task LoanSaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
