using MediatR;

namespace LibraryManagementSystem.Application.Commands.LoanUpdate
{
    public class LoanUpdateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
    }
}
