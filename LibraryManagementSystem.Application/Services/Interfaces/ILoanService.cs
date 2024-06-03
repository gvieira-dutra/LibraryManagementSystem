using LibraryManagementSystem.Application.ViewModels;

namespace LibraryManagementSystem.Application.Services.Interfaces
{
    public interface ILoanService 
    {
        public List<LoanViewModel> LoanGetAll();
        public LoanViewModel LoanGetById(int id);
        public List<LoanViewModel> LoanGetByUserId(int userId);
        public int LoanCreate(LoanCreateModel newLoan);
        public int LoanUpdate(LoanUpdateModel updateLoan);

    }
}
