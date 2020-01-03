using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableNS
{
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

        public Table(string name, int legs, int priceIn) : this()
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



        public override bool Equals(object table)
        {
            Table tableToCompare = (Table)table;
            if (Legs == tableToCompare.Legs && Name == tableToCompare.Name)
                return true;
            else return false;
        }

        public override int GetHashCode() => Name.GetHashCode() + Legs.GetHashCode();

        public override string ToString() => "Name: " + Name + ", legs: " + Legs;

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
                return _items.Count();
            }
        }

        private T[] _items = new T[0];

        // индексатор
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }

        public void addItem(T item)
        {
            Array.Resize(ref _items, _items.Count() + 1);
            _items[_items.Count() - 1] = item;
        }

        public void removeItem(T item)
        {
            int index = Array.IndexOf(_items, item);
            for (int i = index; i < _items.Count() - 1; i++)
                _items[i] = _items[i + 1];
            Array.Resize(ref _items, _items.Count() - 1);
        }

        public T[] getItems()
        {
            return _items;
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
                return _items.Count();
            }
        }

        private T[] _items = new T[0];

        public void addItem(T item)
        {
            Array.Resize(ref _items, _items.Count() + 1);
            _items[_items.Count() - 1] = item;
        }

        public void removeItem(T item)
        {
            int index = Array.IndexOf(_items, item);
            for (int i = index; i < _items.Count() - 1; i++)
                _items[i] = _items[i + 1];
            Array.Resize(ref _items, _items.Count() - 1);
        }

        public T[] getItems()
        {
            return _items;
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
