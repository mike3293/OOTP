using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    public partial class Press
    {
        public Press(string title, Author author, Publisher publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }

        public double Cost { get; set; }
        public double Year { get; set; }    // Можно добавить в конструктор, но не сегодня


        public override string ToString()
        {
            return "Title: " + Title + ", Author: " + Author.Name + ", Publisher: " + Publisher.PubName;
        }
    }
}
