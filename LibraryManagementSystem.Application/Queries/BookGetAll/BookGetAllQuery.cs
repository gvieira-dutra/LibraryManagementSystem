using LibraryManagementSystem.Application.ViewModels;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.BookGetAll
{
    public class BookGetAllQuery : IRequest<List<BookViewModel>>
    {
        public BookGetAllQuery(string query)
        {
            this.query = query;
        }

        public string query { get; private set; }
    }
}
