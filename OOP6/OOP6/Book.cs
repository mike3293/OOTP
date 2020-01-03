using System;

namespace OOP_5_6
{
    public class Book : Press, IRustling
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
