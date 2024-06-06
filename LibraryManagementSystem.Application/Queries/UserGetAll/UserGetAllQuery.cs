using LibraryManagementSystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries.UserGetAll
{
    public class UserGetAllQuery : IRequest<List<UserViewModel>>
    {
        public UserGetAllQuery(string query)
        {
            this.query = query;
        }
        public string query { get; private set; }
    }
}
