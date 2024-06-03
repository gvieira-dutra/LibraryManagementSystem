using Dapper;
using LibraryManagementSystem.Application.Services.Interfaces;
using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryManagementSystem.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly LibMgmtSysDbContext _dbContext;
        private readonly string _connectionString;

        public UserService(LibMgmtSysDbContext dbContext, IConfiguration configuration)
        {
            _dbContext= dbContext;
            _connectionString= configuration.GetConnectionString("LibraryMgmtSysCs");
        }


        public int UserCreateNew(UserCreateNewModel model)
        {
            var user = new User(model.Username, model.FullName, model.Email);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public List<UserViewModel>? UserGetAll(string query)
        {

            var users = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                users = users
                        .Where(u => u.FullName.Contains(query));
            }

            var userVM = users.Select
                        (u => new UserViewModel(u.Username, u.FullName, u.Email))
                        .ToList();

            return userVM ?? null;
        }

        public UserDetailViewModel UserGetById(int id)
        {

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Username, FullName, Email " +
                             "FROM Users WHERE Id = @id";

                return sqlConnection.QueryFirstOrDefault<UserDetailViewModel>(script, new { id });
            }
        }
    }
}
