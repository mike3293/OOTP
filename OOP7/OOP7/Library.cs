using System;
using System.Collections.Generic;

namespace OOP_5_6_7
{
    public class Library
    {
        private List<Press> _printEx = new List<Press>();
        public Press this[int index]
        {
            get
            {
                if (index > _printEx.Count)
                {
                    Console.WriteLine("Превышен максимальный индекс списка печатных изданий");
                    return null;
                }
                return _printEx[index];
            }
            set
            {
                if (index > _printEx.Count)
                {
                    Console.WriteLine("Элемента с таким индексом не существует");
                }
                else
                {
                    _printEx[index] = value;
                }
            }
        }
        public void Add(Press a) { _printEx.Add(a); }
        public void Del(Press d) { _printEx.Remove(d); }

        public void Show()
        {
            if (_printEx.Count == 0)
            {
                throw new EmptyException("No items in library");
            }
            Console.WriteLine("What is your name?");
            string answer = Console.ReadLine();
            if (answer == "misha")
            {
                Console.WriteLine("List:");
                for (int i = 0; i < _printEx.Count; i++)
                {
                    Console.WriteLine("Press[{0}] = {1}", i, _printEx[i].Title);
                }
            }
            else
            {
                throw new SecretException("Your are not an owner");
            }

        }
        public void ShowFromYear(int year)
        {
            Console.WriteLine("List of books the year of publication of which is more than {0}", year);
            for (int i = 0; i < _printEx.Count; i++)
            {
                if (_printEx[i].Year >= year)
                {
                    Console.WriteLine("Press[{0}] = {1} {2}", i, _printEx[i].Title, _printEx[i].Year);
                }
            }
        }
        public int CountOfBooks()
        {
            return _printEx.Count;
        }

        public double CostOfBooks()
        {
            double cost = 0;
            for (int i = 0; i < _printEx.Count; i++)
            {
                cost += _printEx[i].Cost;
            }

            return cost;
        }
    }
}
