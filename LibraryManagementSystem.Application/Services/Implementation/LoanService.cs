using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
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

        var loans = _dbContext.Loans
            .Where(l => l.LoanCurrStatus != Core.Enums.LoanStatus.Returned)
            .Include(l => l.Book)
            .Include(l => l.User);

        if (loans == null) return null;

        var loansVM = loans.Select(l => new LoanViewModel(
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

    public LoanViewModel LoanGetById(int id)
    {
        var loan = _dbContext.Loans
            .Include(l => l.Book)
            .Include(l => l.User)
            .SingleOrDefault(l => l.Id == id);

        if (loan != null )
        {
            LoanCheckLate(id);

            var loanVM = new LoanViewModel(
                loan.Id,
                loan.UserId,
                loan.BookId,
                loan.LoanStartDate,
                loan.LoanCurrStatus.ToString(),
                loan.Book.Title,
                loan.User.FullName);
        
                return loanVM ;
        }

        return null;
    }

    public List<LoanViewModel> LoanGetByUserId(int userId)
    {
        var loans = _dbContext.Loans.Where(l => l.UserId == userId)
            .Include(l => l.Book)
            .Include(l => l.User);
        
        if (loans.Any())
            {

            foreach (var l in loans)
            {
                LoanCheckLate(l.Id);
            }

            var loansVM = loans.Select(l => new LoanViewModel(
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

    public int LoanCreate(LoanCreateModel newLoan)
    {
        var book = _dbContext.Books.SingleOrDefault(b => b.Id == newLoan.IdBook);

        if (book != null && book.Availability == Core.Enums.BookStatus.Available) 
        {
            var loan = new Loan(newLoan.IdUser, newLoan.IdBook);

            _dbContext.Loans.Add(loan);

            book.BookSetUnavailable();
            _dbContext.SaveChanges();

            return loan.Id;
        }

        return 0;
    }

    public string LoanEnd(int id)
    {
        var loan = _dbContext.Loans
            .Include(l => l.Book)
            .SingleOrDefault(l =>l.Id == id);


        var message = "";

        if (loan != null)
        {
            LoanCheckLate(id);

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

            _dbContext.SaveChanges();
        }

        return message;
    }

    public int LoanUpdate(LoanUpdateModel updateLoan)
    {
        var loan = _dbContext.Loans.SingleOrDefault(l => l.Id == updateLoan.Id);

        if (loan == null) { return 0; }

        loan.Update(updateLoan.IdUser, updateLoan.IdBook);
        _dbContext.SaveChanges();

        return loan.Id;
    }

    private void LoanCheckLate(int id)
    {
        var loan = _dbContext.Loans.SingleOrDefault(l => l.Id == id);

        if (loan != null && loan.LoanFinishDate < DateTime.Now) 
        {
             loan.LoanSetLate();
            _dbContext.SaveChanges();
        }
    }

}