using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class Journal:Press
    {

        public Journal(string title, Author author, Publisher publisher, int number) : base(title, author, publisher)
        {
            Number = number;
        }

        public int Number { get; set; }


    }
}
