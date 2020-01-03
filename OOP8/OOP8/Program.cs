using System;

namespace OOP8
{
    internal struct Workbook
    {
        public string firstName;
        public string lastName;
        public string Title;
        public Workbook(string name, string sname, string title)
        {
            firstName = name;
            lastName = sname;
            Title = title;
        }
        public void Info()
        {
            Console.WriteLine("The author of " + Title + " is " + firstName + " " + lastName + ".");
        }
        public override string ToString()
        {
            return "The author of " + Title + " is " + firstName + " " + lastName + ".";
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                CollectionType<int> list = new CollectionType<int>();

                //list.Show();              //exception
                list.Add(9);
                //list.Add(0);              //exception
                list.Add(78);
                list.Add(22);
                list.Add(54);
                list.Add(20);
                list.Add(1);
                list.Add(58);
                list.Add(77);
                list.Show();

                Workbook a = new Workbook("Jo", "Марлей", "'book one'");
                Workbook b = new Workbook("Go", "Barley", "'book two'");
                CollectionType<Workbook> wb1 = new CollectionType<Workbook>();
                CollectionType<Workbook> wb2 = new CollectionType<Workbook>();
                wb1.Add(a);
                wb1.Add(b);
                //list.ToFile(list);
                //list.FromFile();
                wb1.ToFile(wb1);
                wb1.FromFile();
                Console.WriteLine("Without exceptions!!!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("The end.");
            }

        }
    }

}
