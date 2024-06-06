using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Application.Queries.UserGetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, List<UserViewModel>>
    {
        private readonly LibMgmtSysDbContext _dbContext;
        private readonly string _connectionString;

        public UserGetAllQueryHandler(LibMgmtSysDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("LibraryMgmtSysCs");
        }
        public async Task<List<UserViewModel>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var users = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(request.query))
            {
                users = users
                        .Where(u => u.FullName.Contains(request.query));
            }

            var userVM = await users.Select(u => new UserViewModel(u.Username, u.FullName, u.Email)).ToListAsync();

            return userVM;
        }
    }
}
