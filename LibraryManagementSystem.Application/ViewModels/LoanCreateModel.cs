using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.ViewModels
{
    public class LoanCreateModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime BorrowedAt { get; set; }
    }
}
