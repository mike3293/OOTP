using System;
using System.Collections.Generic;

namespace TableNS
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table1 = new Table("Transparent3000", 3, 100);
            Table table2 = new Table("Transparent3000", 3, 100);
            Table table3 = new Table("Metal", 6, 200);

            //table1.Price = 10;

            Console.WriteLine(table1.Price);

            Console.WriteLine($"table1 == table2 : {table1.Equals(table2)}");

            Console.WriteLine($"table1 and table2 hash: {table1.GetHashCode()} ; {table3.GetHashCode()}");

            Console.WriteLine($"{ table1.ToString()}\n{ table3.ToString()}");
            string type;
            Table.showType(out type);

            var AnonimusTable = new
            {
                Legs = 4,
                Name = "Basic",
                Width = 100,
                Height = 50,
                Depth = 200,
                price = 0
            };



       

            List<Table> list1 = new List<Table>();
            list1.addItem(table1);
            list1.addItem(table2);
            list1.addItem(table3);

            Console.WriteLine($"\nFirst element of list1: {list1[0]}");

            list1.printAll();

            list1.removeItem(table1);

            Console.WriteLine("\nlist1:");
            list1.printAll();

            Table table4 = new Table();
            Table table5 = new Table();

            Console.WriteLine($"\ntable2 in list1 : {list1.isInList(table2)}\n");
            List<Table> list2 = new List<Table>();
            list2.addItem(table4);
            list2.addItem(table5);

            Console.WriteLine("\nlist2:");
            list2.printAll();

            list1.Merge(list2);

            Console.WriteLine("\nList1 and list2 together:");
            list1.printAll();

            Console.WriteLine($"Lenght of new list1: {list1.Count}");


            ListSingle<Table> list3 = ListSingle<Table>.getInstance();
            ListSingle<Table> list4 = ListSingle<Table>.getInstance();

            list3.addItem(table1);
            list3.printAll();
            list4.printAll();

            table1.Dispose();

            Console.ReadLine();
        }
        
        
    }
}