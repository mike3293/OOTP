using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OOP_5_6_7
{
    struct Information
    {
        public string book;
        public string author;
    }
    enum BookType     
    {
        PrintEdition, Workbook, Journal = 5, Book
    }

    class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("book1 as SchoolBook == null");


            Information info;
            info.book = "Пикник";

            BookType mag = BookType.Journal;

            Console.WriteLine((int)mag);

            Press book01 = new Book("c#", author1, pub1, "programming");
            Press book02 = new SchoolBook("Pascal", author1, pub1, "programming", 10);
            Press book03 = new Journal("Pascal", author1, pub1, 1);

            book02.Year = 100;
            book03.Year = 80;
            book01.Year = 70;
            Library library = new Library();
            LibraryController libraryControl = new LibraryController();

            library.Add(book01);
            library.Add(book02);
            library.Add(book03);

            Console.WriteLine(library[0]);

            libraryControl.ShowFromYear(library, 80);

            Console.WriteLine(libraryControl.Count(library));

            int[] aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");


            try
            {
                

                int a = 0;
                //int b = 4/a;  

                library.Show();     // incorrect password

                //Author author0 = new Author("", 13, new Book[0]);     // No name author

                Library libraryEx = new Library();
                // libraryEx.Show();       // No items
            }
            catch (EmptyException exception)
            {
                exception.GetInfo();
            }
            catch (NoNameException exception)
            {
                exception.GetInfo();
            }
            catch (SecretException exception)
            {
                exception.GetInfo();
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine(exception.TargetSite);
                throw;
            }
            catch
            {
                Console.WriteLine("Unknown error");
            }
            finally
            {
                Console.WriteLine("FINALLY");
            }

            Console.ReadKey();
        }

        
    }
}
