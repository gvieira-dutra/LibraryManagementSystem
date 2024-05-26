using LibraryManagementSystem.Application.ViewModels;

namespace LibraryManagementSystem.Application.Services.Interfaces
{
    public interface IUserService
    {
        public int UserCreateNew(UserCreateNewModel model);
        public List<UserViewModel>? UserGetAll(string query);
        public UserDetailViewModel? UserGetById(int id);
    }
}
