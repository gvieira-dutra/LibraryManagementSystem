using LibraryManagementSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
            LoanCurrStatus = LoanStatus.Active;
            LoanDate = DateTime.Now;
        }

        public int UserId { get; private set; }
        public int BookId { get; private set; }
        public LoanStatus LoanCurrStatus { get; private set; }
        public DateTime LoanDate { get; private set; }

        public void Update(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
