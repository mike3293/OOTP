using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    public class Journal:Press, IRustling
    {

        public Journal(string title, Author author, Publisher publisher, int number) : base(title, author, publisher)
        {
            Number = number;
        }

        public int Number { get; set; }


        public void rustle()
        {
            Console.WriteLine("Шуршит как журнал");
        }

    }
}
