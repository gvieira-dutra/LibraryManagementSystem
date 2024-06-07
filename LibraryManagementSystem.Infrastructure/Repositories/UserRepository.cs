using Dapper;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class UserRepository(LibMgmtSysDbContext dbContext, IConfiguration configuration) 
        : IUserRepository
    {
        private readonly LibMgmtSysDbContext _dbContext = dbContext;
        private readonly string _connectionString = configuration.GetConnectionString("LibraryMgmtSysCs");

        public async Task<List<User>> UserGetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> UserGetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Username, FullName, Email " +
                "FROM Users WHERE Id = @id";


                var user = await sqlConnection.QueryFirstOrDefaultAsync<User>(script, new { id });

                return user;
            }
        }
    
        public async Task<int> UserCreateAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            
            return user.Id;
        }
    }
}
