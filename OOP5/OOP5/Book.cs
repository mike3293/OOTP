using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class Book : Press
    {
        public Book(string title, Author author, Publisher publisher, string genre) : base(title, author, publisher)
        {
            Genre = genre;
        }

        public string Genre { get; set; }

    }
}
