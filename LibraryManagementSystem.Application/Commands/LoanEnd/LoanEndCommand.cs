using MediatR;

namespace LibraryManagementSystem.Application.Commands.LoanEnd
{
    public class LoanEndCommand : IRequest<string>
    {
        public LoanEndCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
