using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP8
{
    //Создайте обобщенный класс на основе 4 л.р.
    //Наследуйте обобщенный интерфейс, реализуйте необходимые методы.
    //Наложите какое-либо ограничение на обобщение.
    public class CollectionType<T> : IFunction<T> where T : struct
    {
        public List<T> List { get; set; }

        public int Count
        {
            get
            {
                return List.Count;
            }
        }

        public CollectionType()
        {
            List = new List<T>();
        }

        public T this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public void Add(T el)
        {
            if (el.Equals(0))
            {
                throw new Exception("***You cannot add element with a value of 0***");
            }
            List.Add(el);
        }

        public void Show()
        {
            if (List.Count == 0)
            {
                throw new Exception("***Empty List***");
            }
            for (int i = 0; i < List.Count; i++)
            {
                Console.WriteLine((i + 1) + " element of list: " + List[i]);
            }
        }

        public void Remove(int pos)
        {
            List.RemoveAt(pos);
        }
        
        //Добавьте методы сохранения объекта (объектов) обобщённого типа CollectionType<T> в файл и чтения из него.
        public void ToFile(CollectionType<T> type)
        {
            int index = type.Count;
            string[] text = new string[index];
            for (int i = 0; i < index; i++)
            {
                text[i] = Convert.ToString(type[i]);
            }
            File.WriteAllLines("D:/oop_8.txt", text);
        }

        public void FromFile()
        {
            Console.WriteLine(File.ReadAllText("D:/oop_8.txt"));
        }
    }
}

