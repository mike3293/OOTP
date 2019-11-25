using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace OOP14
{
    [Serializable]  //объект доступен для служб сериализации
    public abstract class Author
    {
        protected string firstName;
        protected string lastName;
        
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }
        
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }
  
    }

    [Serializable]
    public class Book : Author
    {
        protected string nameOfW;

        public Book()
        {
            firstName = "Unknown";
            lastName = "Non";
            nameOfW = "Book";
        }
        public Book(string name, string sname, string nameOfW)
        {
            firstName = name;
            lastName = sname;
            this.nameOfW = nameOfW;
        }
       
        public string NameOfW
        {
            get => nameOfW;
            set => nameOfW = value;
        }

        public void Info()
        {
            Console.WriteLine("The author of " + NameOfW + " is " + FirstName + " " + LastName + ".");
        }
    }
}
