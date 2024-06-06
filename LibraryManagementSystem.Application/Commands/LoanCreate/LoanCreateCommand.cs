using MediatR;

namespace LibraryManagementSystem.Application.Commands.LoanCreate
{
    public class LoanCreateCommand : IRequest<int>
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
    }
}
