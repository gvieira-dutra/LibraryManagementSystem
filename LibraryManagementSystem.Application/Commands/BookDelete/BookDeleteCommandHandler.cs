using Dapper;
using LibraryManagementSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Application.Commands.BookDelete
{

    public class BookDeleteCommandHandler : IRequestHandler<BookDeleteCommand, Unit>
    {
        private readonly LibMgmtSysDbContext _dbContext;
        private readonly string _connectionString ;

        public BookDeleteCommandHandler(LibMgmtSysDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _connectionString = config.GetConnectionString("LibraryMgmtSysCs");
        }

        public async Task<Unit> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
        {            
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == request.Id);

                if (book != null)
                {
                    book.BookSetNotInTheSystem();

                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();

                        var script = "UPDATE Books SET Availability = @availability WHERE Id = @id";

                        await sqlConnection.ExecuteAsync(script, new { availability = book.Availability, request.Id});
                    }

                }
            return Unit.Value;
        }

    }
}
