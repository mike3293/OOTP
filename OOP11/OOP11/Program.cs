using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP11
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //1.Задайте массив типа string, содержащий 12 месяцев (June, July, May,December, January ….). 
            //Используя LINQ to Object напишите:
            //запрос выбирающий последовательность месяцев с длиной строки равной n, 
            //запрос возвращающий только летние и зимние месяцы, 
            //запрос вывода месяцев в алфавитном порядке,
            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4 - х..
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n;
            Console.Write("Enter string length n:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Months with a string length of " + n + ":");
            IEnumerable<string> length = months
                .Where(p => (p.Length == n))
                .Select(p => p);
            foreach (string month in length)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("2. Summer and winter months:");
            IEnumerable<string> sumwin = months
                .Where(p => (p.Equals("December") || p.Equals("January") || p.Equals("February") || p.Equals("June") || p.Equals("July") || p.Equals("August")))
                .Select(p => p);
            foreach (string month in sumwin)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("3. Months in alphabetical order:");
            IEnumerable<string> alph = months
                .OrderBy(p => p)
                .Select(p => p);
            foreach (string month in alph)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("4. Months containing a letter 'u' and a length >= 4:");
            IEnumerable<string> contU = months
                .Where(p => (p.Contains('u') && p.Length >= 4))
                .Select(p => p);
            foreach (string month in contU)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine("\n---------------------------------------------------\n");
            Console.ReadKey();
        } 
    }
}
