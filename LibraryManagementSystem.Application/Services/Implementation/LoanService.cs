using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Application.Services.Interfaces;

namespace LibraryManagementSystem.Application.Services.Implementation;

public class LoanService : ILoanService
{
    private readonly LibMgmtSysDbContext _dbContext;

    public LoanService(LibMgmtSysDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<LoanViewModel> LoanGetAll()
    {
        var loans = _dbContext.Loans;

        if (loans == null) return null;

        var loansVM = loans.Select(l => new LoanViewModel(
            l.Id, 
            l.UserId, 
            l.BookId, 
            l.LoanStartDate))
            .ToList() ;

        return loansVM;
    }
    public LoanViewModel LoanGetById(int id)
    {
        var loan = _dbContext.Loans.SingleOrDefault
            (l => l.Id == id);

        var loanVM = new LoanViewModel(
            loan.Id,
            loan.UserId,
            loan.BookId,
            loan.LoanStartDate
            );

        return loanVM;
    }

    public List<LoanViewModel> LoanGetByUserId(int userId)
    {
        var loans = _dbContext.Loans.Where(l => l.UserId == userId);

        var loansVM = new List<LoanViewModel>();
        loans.Select(l => new LoanViewModel(
        l.Id,
        l.UserId,
        l.BookId,
        l.LoanStartDate
        )).ToList();

        return loansVM;
    }

    public int LoanCreate(LoanCreateModel newLoan)
    {
        var loan = new Loan(newLoan.IdUser, newLoan.IdBook);

        _dbContext.Loans.Add(loan);

        return loan.Id;
    }

    public int LoanUpdate(LoanUpdateModel updateLoan)
    {
        var loan = _dbContext.Loans.SingleOrDefault(l => l.Id == updateLoan.Id);

        if (loan == null) { return 0; }

        loan.Update(updateLoan.IdUser, updateLoan.IdBook);

        return loan.Id;
    }

}