using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP10
{
    internal class Author   // : IComparable<Author>
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public Author(string name, int yy)
        {
            FirstName = name;
            Age = yy;
        }
        //public int CompareTo(Author obj)    //IComparable<Author>
        //{
        //    if (Age > obj.Age)
        //    {
        //        return 1;
        //    }

        //    if (Age < obj.Age)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}
