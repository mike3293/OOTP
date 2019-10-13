using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class Author : Person
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
    }
}
