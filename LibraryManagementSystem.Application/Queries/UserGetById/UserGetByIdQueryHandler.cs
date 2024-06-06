using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LibraryManagementSystem.Application.ViewModels;

namespace LibraryManagementSystem.Application.Queries.UserGetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserDetailViewModel>
    {
        private readonly string _connectionString;

        public UserGetByIdQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LibraryMgmtSysCs");
        }
        public async Task<UserDetailViewModel> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Username, FullName, Email " +
                             "FROM Users WHERE Id = @id";


                var user = await sqlConnection.QueryFirstOrDefaultAsync<UserDetailViewModel>(script, new { request.Id });

                return user;
            }
        }
    }
}
