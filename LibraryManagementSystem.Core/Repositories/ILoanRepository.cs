using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> LoanGetAllAsync();
        Task<Loan> LoanGetByIdAsync(int id);
        Task<List<Loan>> LoanGetByUserIdAsync(int it);
        Task<int> LoanCreateAsync(Loan loan);
        Task LoanSaveChangesAsync();
    }
}
