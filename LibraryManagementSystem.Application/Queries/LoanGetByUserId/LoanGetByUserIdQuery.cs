using LibraryManagementSystem.Application.Queries.LoanGetAll;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.LoanGetByUserId
{
    public class LoanGetByUserIdQuery : IRequest<List<LoanDetailViewModel>>
    {
        public LoanGetByUserIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
