using System;
using System.Collections.Generic;
using System.IO;

namespace OOP8
{
    //Создайте обобщенный класс на основе 4 л.р.
    //Наследуйте обобщенный интерфейс, реализуйте необходимые методы.
    //Наложите какое-либо ограничение на обобщение.
    public class CollectionType<T> : IFunction<T> where T : struct
    {
        public List<T> List { get; set; }

        public int Count => List.Count;

        public CollectionType()
        {
            List = new List<T>();
        }

        public T this[int index]
        {
            get => List[index];
            set => List[index] = value;
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

        public void ToFile(CollectionType<T> type)
        {
            int index = type.Count;
            string[] text = new string[index];
            for (int i = 0; i < index; i++)
            {
                text[i] = type[i].ToString();
            }
            File.WriteAllLines("oop_8.txt", text);
        }

        public void FromFile()
        {
            Console.WriteLine(File.ReadAllText("oop_8.txt"));
        }
    }
}

