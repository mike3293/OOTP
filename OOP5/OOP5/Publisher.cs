using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class Publisher
    {
        public Publisher(string name, Press[] press, Author[] authors)
        {
            Press = press;
            Authors = authors;
            PubName = name;
        }
        public string PubName { get; set; }
        public Press[] Press { get; set; }
        public Author[] Authors { get; set; }
        public override string ToString()
        {
            return "Name: " + PubName + ". Amount of press: " + Press.Length + ", authors: " + Authors.Length;
        }
    }
}
