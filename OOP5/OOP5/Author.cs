using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    sealed class Author : Person, IWrite
    {
        public Author(string name, int age, Book[] press):base(name, age)
        {
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
