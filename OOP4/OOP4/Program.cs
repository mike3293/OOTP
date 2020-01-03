using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyList.Owner owner = new MyList.Owner(12, "Mikhail", "BSTU");
            MyList.Date date = new MyList.Date();
            Console.WriteLine($"{date}\n");

            MyList myList = new MyList() { "1", "MAXWORD", "3" };
            MyList myList2 = new MyList() { "1", "2", "3" };

            Console.WriteLine(myList);

            string tmp = "4";
            myList = myList + (tmp, 1);
            Console.WriteLine(myList);

            myList = myList >> 1;   // перегрузка
            Console.WriteLine(myList);

            Console.WriteLine(myList != myList2);

            Console.WriteLine($"Max word in list: {myList.MaxWord()}");     // два метода расширения

            Console.WriteLine($"Del last: {myList.DelLast()}\n");

            MyList myList3 = new MyList() { "abcd", "ac", "ery", "q" };
            Console.WriteLine(myList3);

            Console.WriteLine($"Sum list3: {StatisticOperation.sum(myList3)}");
            Console.WriteLine($"list3 diff: {StatisticOperation.diff(myList3)}");
            Console.WriteLine(StatisticOperation.count(myList3));

            Console.ReadKey();
        }
    }

}
