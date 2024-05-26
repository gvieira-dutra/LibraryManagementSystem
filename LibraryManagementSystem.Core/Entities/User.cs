
namespace LibraryManagementSystem.Core.Entities
{
    public class User(string username, string fullName, string email) : BaseEntity
    {
        public string Username { get; private set; } = username;
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
        public List<Loan> Loans { get; private set; } = new List<Loan>();
    }
}
