using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class Press
    {
        public Press(string title, Author author, Publisher publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }

        public override string ToString()
        {
            return "Title: " + Title + ", Author: " + Author.Name + ", Publisher: " + Publisher.PubName;
        }
    }
}
