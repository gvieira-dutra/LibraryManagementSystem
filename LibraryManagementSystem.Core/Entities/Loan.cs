using LibraryManagementSystem.Core.Enums;

namespace LibraryManagementSystem.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
            LoanCurrStatus = LoanStatus.Active;
            LoanStartDate = DateTime.Now;
            LoanFinishDate = LoanStartDate.AddDays(7);
        }

        public int UserId { get; private set; }
        public User User { get; private set; }
        public int BookId { get; private set; }
        public Book Book { get; private set; }
        public LoanStatus LoanCurrStatus { get; private set; }
        public DateTime LoanStartDate { get; private set; }
        public DateTime LoanFinishDate { get; private set; }

        public void Update(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }

        public void LoanSetReturned()
        {
            LoanCurrStatus = LoanStatus.Returned;
        }

        public void LoanSetLate()
        {
            LoanCurrStatus = LoanStatus.Late;
        }

        public void LoanCheckLate()
        {
            if( LoanFinishDate < DateTime.Now)
            {
                LoanSetLate();
            }
        }

    }
}
