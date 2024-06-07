using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.UserCreateNew
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Username, request.FullName, request.Email);

            return await _userRepository.UserCreateAsync(user);
        }
    }
}
