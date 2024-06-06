using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.UserCreateNew
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, int>
    {
        private readonly LibMgmtSysDbContext _dbContext;

        public UserCreateCommandHandler(LibMgmtSysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Username, request.FullName, request.Email);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
