using MediatR;

namespace LibraryManagementSystem.Application.Commands.BookDelete
{

    public class BookDeleteCommand : IRequest<Unit>
    {
        public BookDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
