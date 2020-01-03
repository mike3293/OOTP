using System;

namespace OOP5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Лаба с иерархией

            Author author1 = new Author("Влад", 13, new Book[0]);
            Author author2 = new Author("Влад2", 14, new Book[0]);
            Printer.IAmPrinting(author1);
            author1.write();
            IWrite authorX = new Author("Влад2", 14, new Book[0]);
            authorX.write();



            Author[] authArr = { author1, author2 };
            Console.WriteLine(author1);

            Publisher pub1 = new Publisher("Питер", new Press[0], authArr);

            Console.WriteLine(pub1);

            Book book1 = new Book("aa", author1, pub1, "s");
            SchoolBook book2 = new SchoolBook("aa", author1, pub1, "s", 5);

            Console.WriteLine(book2 is Book);


            Printer.IAmPrinting(author1);

            if ((book1 as SchoolBook) == null)
            {
                Console.WriteLine("book1 as SchoolBook == null");
            }

            Console.ReadKey();
        }


    }
}
