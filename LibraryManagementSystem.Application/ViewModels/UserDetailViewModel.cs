using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.ViewModels
{
    public class UserDetailViewModel(string username, string fullName, string email)
    {
        public string Username { get; set; } = username;
        public string FullName { get; set; } = fullName;
        public string Email { get; set; } = email;
        //public List<Loan> Loans { get; set; } = loans;
    }
}
