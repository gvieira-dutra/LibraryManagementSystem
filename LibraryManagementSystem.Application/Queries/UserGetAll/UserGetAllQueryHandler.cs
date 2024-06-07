using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Queries.UserGetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public UserGetAllQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserViewModel>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.UserGetAllAsync();

            if (!string.IsNullOrEmpty(request.query))
            {
                users = users
                        .Where(u => u.FullName.Contains(request.query)).ToList();
            }

            var userVM = users.Select(u => new UserViewModel(u.Username, u.FullName, u.Email)).ToList();

            return userVM;
        }
    }
}
