using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> BookGetAllAsync(string query);
        Task<Book> BookGetOneAsync(int id);
        Task<int> BookCreateAsync(Book book);
        Task BookDeleteAsync(Book book);


    }
}
