using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, int idUser, int idBook, DateTime loanDate)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = loanDate;
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
