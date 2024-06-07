using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Repositories;

namespace LibraryManagementSystem.Application.Queries.UserGetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserDetailViewModel>
    {
        private readonly IUserRepository _userRepository;

        public UserGetByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDetailViewModel> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.UserGetByIdAsync(request.Id);

            return new UserDetailViewModel(user.Username, user.FullName, user.Email);

        }
    }
}
