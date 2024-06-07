using LibraryManagementSystem.Core.Entities;

namespace LibraryManagementSystem.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> UserGetAllAsync();
        Task<User> UserGetByIdAsync(int id);
        Task<int> UserCreateAsync(User user);
    }
}
