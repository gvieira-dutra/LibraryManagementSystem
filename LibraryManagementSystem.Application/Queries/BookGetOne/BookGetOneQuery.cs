using LibraryManagementSystem.Application.ViewModels;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.BookGetOne
{
    public class BookGetOneQuery : IRequest<BookViewModel>
    {
        public BookGetOneQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
