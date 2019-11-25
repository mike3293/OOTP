using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class SchoolBook:Book
    {
            public SchoolBook(string title, Author author, Publisher publisher, string genre, int grade) :base(title, author, publisher, genre)
            {
                Grade = grade;
            }

            public int Grade { get; set; }

        
    }
}
