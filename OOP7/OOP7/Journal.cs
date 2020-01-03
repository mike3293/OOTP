using System;

namespace OOP_5_6_7
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
