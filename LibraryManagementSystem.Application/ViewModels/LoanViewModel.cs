
namespace LibraryManagementSystem.Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, int idUser, int idBook, string bookTitle)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            BookTitle = bookTitle;
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public string BookTitle { get; set; }
    }
}
