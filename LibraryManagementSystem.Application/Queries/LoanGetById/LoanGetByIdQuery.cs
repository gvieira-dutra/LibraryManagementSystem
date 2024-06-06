

using LibraryManagementSystem.Application.Queries.LoanGetAll;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.LoanGetById
{
    public class LoanGetByIdQuery : IRequest<LoanDetailViewModel>
    {
        public LoanGetByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
