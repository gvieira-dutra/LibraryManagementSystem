using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    internal class User : BaseEntity
    {
        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public string Username { get; private set; }
        public string Email { get; private set; }
    }
}
