using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("Влад", 13, null);
            Author author2 = new Author("Влад2", 14, null);

            Author[] authArr = { author1, author2 };
            Console.WriteLine(author1);

            Publisher pub1 = new Publisher("Питер", null, authArr);

            Console.WriteLine(pub1);

            Console.ReadKey();
        }

        
    }
}
