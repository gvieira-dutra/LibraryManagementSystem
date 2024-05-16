using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Application.Services.Interfaces;

namespace LibraryManagementSystem.Application.Services.Implementation;

public class LoanService : ILoanService
{
    private readonly LibraryManagementSystemDbContext _dbContext;

    public LoanService(LibraryManagementSystemDbContext dbContext)
    {
        dbContext = _dbContext;
    }
    public List<LoanViewModel> LoanGetAll()
    {
        var loans = _dbContext.Loans;

        var loansVM = loans.Select(l => new LoanViewModel(l.Id, l.UserId, l.BookId, l.LoanDate))
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
            loan.LoanDate
            );

        return loanVM;
    }

    public LoanViewModel LoanGetByUserId(int userId)
    {
        var loan = _dbContext.Loans.SingleOrDefault
    (l => l.UserId == userId);

        var loanVM = new LoanViewModel(
            loan.Id,
            loan.UserId,
            loan.BookId,
            loan.LoanDate
            );

        return loanVM;
    }

    public int LoanCreate(LoanCreateModel newLoan)
    {
        var loan = new Loan(newLoan.IdUser, newLoan.IdBook);

        _dbContext.Loans.Add(loan);

        return loan.Id;
    }

    public int LoanUpdate(LoanViewModel updateLoan)
    {
        var loan = _dbContext.Loans.SingleOrDefault(l => l.Id == updateLoan.Id);

        loan.Update(updateLoan.IdUser, updateLoan.IdBook);

        return loan.Id;
    }

    public void LoanDelete(int id)
    {
        var loan = _dbContext.Loans.SingleOrDefault(l => l.Id == id);
        _dbContext.Loans.Remove(loan); 
    }
}