using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookCreateNew
{
    public class BookCreateNewCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISNB { get; set; }
        public int PublicationYear { get; set; }
    }
}
