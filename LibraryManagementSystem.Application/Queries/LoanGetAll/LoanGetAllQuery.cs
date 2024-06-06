using LibraryManagementSystem.Application.ViewModels;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.LoanGetAll
{
    public class LoanGetAllQuery : IRequest<List<LoanViewModel>>
    {
    }
}
