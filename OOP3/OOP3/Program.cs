﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


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

    public partial class Table : IDisposable
    {
        ~Table()
        {
            Console.WriteLine("Object deleted");
            GC.SuppressFinalize(this);
        }

        public Table()
        {
            _legs = 4;
            Name = "Basic";
            Width = 100;
            Height = 50;
            Depth = 200;
            price = 0;
        }

        public Table(string name ,int legs, int priceIn) : this()
        {
            Legs = legs;
            Name = name;
            price = priceIn;
        }

        static Table()
        {
            type = "furniture";
            Console.WriteLine("Once");
        }

        public Table(Table anyTable)
        {
            Legs = anyTable.Legs;
            Name = anyTable.Name;
        }

        public bool Equals(Table tableToCompare)
        {
            if (Legs == tableToCompare.Legs && Name == tableToCompare.Name)
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Legs.GetHashCode();
        }

        public override string ToString()
        {
            return "Name: " + Name + ", legs: " + Legs;
        }

        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Console.WriteLine("dispose");
                Console.ReadLine();
            }

            disposed = true;
        }
    }


    public class List<T>
    {
        public int Count
        {
            get
            {
               return items.Count();
            }
        }

        private T[] items = new T[0];

        // индексатор
        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public void addItem(T item)
        {
            Array.Resize(ref items, items.Count() + 1);
            items[items.Count() - 1] = item;
        }

        public void removeItem(T item)
        {
            int index = Array.IndexOf(items, item);
            for (int i = index; i < items.Count() - 1; i++)
                items[i] = items[i+1];
            Array.Resize(ref items, items.Count() - 1);
        }

        public IEnumerable<T> getItems()
        {
            return items;
        }

        public void printAll()
        {
            Console.WriteLine();
            foreach (var oneitem in getItems())
            {
                Console.WriteLine(oneitem);
            }
            Console.WriteLine();
        }

        public bool isInList(T item)
        {
            bool rc = false;
            foreach (var oneitem in getItems())
            {
                if (item.ToString() == oneitem.ToString()) rc = true;
            }
            return rc;
        }

        public void Merge(List<T> listToMerge)
        {
            foreach (var oneitem in listToMerge.getItems())
            {
                if (!(isInList(oneitem))) addItem(oneitem);
            }
        }

       
    }


    public class ListSingle<T>
    {
        private static ListSingle<T> instance;

        public static ListSingle<T> getInstance()
        {
            if (instance == null)
                instance = new ListSingle<T>();
            return instance;
        }

        public int Count
        {
            get
            {
                return items.Count();
            }
        }

        private T[] items = new T[0];

        public void addItem(T item)
        {
            Array.Resize(ref items, items.Count() + 1);
            items[items.Count() - 1] = item;
        }

        public void removeItem(T item)
        {
            int index = Array.IndexOf(items, item);
            for (int i = index; i < items.Count() - 1; i++)
                items[i] = items[i + 1];
            Array.Resize(ref items, items.Count() - 1);
        }

        public IEnumerable<T> getItems()
        {
            return items;
        }

        public void printAll()
        {
            Console.WriteLine();
            foreach (var oneitem in getItems())
            {
                Console.WriteLine(oneitem);
            }
            Console.WriteLine();
        }

        public bool isInList(T item)
        {
            bool rc = false;
            foreach (var oneitem in getItems())
            {
                if (item.ToString() == oneitem.ToString()) rc = true;
            }
            return rc;
        }

        public void Merge(List<T> listToMerge)
        {
            foreach (var oneitem in listToMerge.getItems())
            {
                if (!(isInList(oneitem))) addItem(oneitem);
            }
        }
    }
}