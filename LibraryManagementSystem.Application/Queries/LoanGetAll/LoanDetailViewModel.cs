namespace LibraryManagementSystem.Application.Queries.LoanGetAll
{
    public class LoanDetailViewModel
    {
        public LoanDetailViewModel(int id, int idUser, int idBook, DateTime loanDate, string status, string user, string bookTitle)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = loanDate;
            Status = status;
            BookTitle = bookTitle;
            UserFullName = user;
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        public string Status { get; set; }
        public string BookTitle { get; set; }
        public string UserFullName { get; set; }
    }
}
