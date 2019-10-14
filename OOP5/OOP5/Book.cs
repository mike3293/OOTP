using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class Book : Press, IRustling
    {
        public Book(string title, Author author, Publisher publisher, string genre) : base(title, author, publisher)
        {
            Genre = genre;
        }

        public string Genre { get; set; }

        public void rustle()
        {
            Console.WriteLine("Шуршит как книга");
        }
    }
}
