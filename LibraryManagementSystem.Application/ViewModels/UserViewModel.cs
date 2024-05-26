
namespace LibraryManagementSystem.Application.ViewModels
{
    public class UserViewModel(string username, string fullName, string email)
    {
        public string Username { get; set; } = username;
        public string FullName { get; set; } = fullName;
        public string Email { get; set; } = email;
    }
}
