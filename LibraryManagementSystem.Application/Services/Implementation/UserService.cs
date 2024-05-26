using LibraryManagementSystem.Application.Services.Interfaces;
using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Infrastructure.Persistence;

namespace LibraryManagementSystem.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public UserService(LibMgmtSysDbContext dbContext)
        {
            _dbContext= dbContext;
        }


        public int UserCreateNew(UserCreateNewModel model)
        {
            var user = new User(model.Username, model.FullName, model.Email);

            _dbContext.Users.Add(user);

            return user.Id;
        }

        public List<UserViewModel>? UserGetAll(string query)
        {
            var users = _dbContext.Users;

            if (!string.IsNullOrEmpty(query))
            {
                users = (List<User>)users
                        .Where(u => u.FullName.Contains(query));
            }

            var userVM = users.Select
                        (u => new UserViewModel(u.Username, u.FullName, u.Email))
                        .ToList();

            return userVM ?? null;
        }

        public UserDetailViewModel? UserGetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null) {return null;}

            var userVM = new UserDetailViewModel(user.Username, user.FullName, user.Email);

            return userVM ?? null;
        }
    }
}
