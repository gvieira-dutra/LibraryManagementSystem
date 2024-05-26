
namespace LibraryManagementSystem.Application.ViewModels
{
    public class LoanCreateModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime BorrowedAt { get; set; }
    }
}
