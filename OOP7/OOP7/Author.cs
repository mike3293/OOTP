using System;

namespace OOP_5_6_7
{
    public sealed class Author : Person, IWrite
    {
        public Author(string name, int age, Book[] press):base(name, age)
        {
            if (name.Length == 0)
            {
                throw new NoNameException("The author isn't named");
            }
            Press = press;
        }
        public Press[] Press { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + ". Amount of books: " + Press.Length + ", age: " + Age;
        }

        void IWrite.write()
        {
            Console.WriteLine("Автор пишет интерфейс");
        }

        public override void write()
        {
            Console.WriteLine("Автор пишет абстрактно");

        }
    }
}
