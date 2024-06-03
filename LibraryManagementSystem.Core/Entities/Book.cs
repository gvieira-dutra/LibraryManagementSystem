using LibraryManagementSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    public class Book(string title, string author, string iSBN, int publicationYear) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string Author { get; private set; } = author;
        public string ISBN { get; private set; } = iSBN;
        public BookStatus Availability { get; private set; } = BookStatus.Available;
        public int PublicationYear { get; private set; } = publicationYear;

        public void BookSetAvailable()
        {
            Availability = BookStatus.Available;
        }

        public void BookSetUnavailable()
        {
            Availability = BookStatus.Unavailable;
        }
        public void BookSetNotInTheSystem()
        {
            Availability = BookStatus.NotInTheSystem;
        }
    }
}
