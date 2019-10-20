using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    public class Library
    {
        List<Press> printEx = new List<Press>();
        public Press this[int index]
        {
            get
            {
                if (index > printEx.Count)
                {
                    Console.WriteLine("Превышен максимальный индекс списка печатных изданий");
                    return null;
                }
                return printEx[index];
            }
            set
            {
                if (index > printEx.Count)
                    Console.WriteLine("Элемента с таким индексом не существует");
                else
                    printEx[index] = value;
            }
        }
        public void Add(Press a) { printEx.Add(a); }
        public void Del(Press d) { printEx.Remove(d); }

        public void Show()
        {
            Console.WriteLine("List:");
            for (int i = 0; i < printEx.Count; i++)
            {
                Console.WriteLine("Press[{0}] = {1}", i, printEx[i].Title);
            }
        }
        public void ShowFromYear(int year)
        {
            Console.WriteLine("List of books the year of publication of which is more than {0}", year);
            for (int i = 0; i < printEx.Count; i++)
            {
                if (printEx[i].Year >= year)
                {
                    Console.WriteLine("Press[{0}] = {1} {2}", i, printEx[i].Title, printEx[i].Year);
                }
            }
        }
        public int CountOfBooks()
        {
            return printEx.Count;
        }

        public double CostOfBooks()
        {
            double cost = 0;
            for (int i = 0; i < printEx.Count; i++)
            {
                cost += printEx[i].Cost;
            }
            
            return cost;
        }
    }
}
