using MediatR;

namespace LibraryManagementSystem.Application.Commands.UserCreateNew
{
    public class UserCreateCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
