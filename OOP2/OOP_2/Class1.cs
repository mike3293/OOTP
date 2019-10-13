using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    class Class1
    {
        class Tasks
        {
            class Example : IDisposable
            {
                private readonly int _state;

                public Example(int state)
                {
                    _state = state;
                }

                public int GetState() => _state;

                public void Dispose()
                {

                }
            }
            static void Main(string[] args)
            {
                
                int intF = 10;
          
                char charF = 'a';

                long longF = 0xFFFFFF;
    
                double doubleF = 10.25;
           
                bool boolF = true;
               
                object objectInt = intF;
                object objectChar = charF;
                object objectLong = longF;
                object objectDouble = doubleF;
                object objectBool = boolF;

                Console.WriteLine(string.Format($"{(int)objectInt}, {objectChar}, {objectLong}, {objectDouble}, {objectBool}"));
               
                int numGroup = 64;
                Console.WriteLine((double)numGroup);
                Console.WriteLine((char)numGroup);
                Console.WriteLine((long)numGroup);
                string name = "Михаил";
                Console.WriteLine(string.Format($"My name is {name}"));
                Console.WriteLine(string.Format("My name is {0}", name));

                string strObj = objectBool.ToString();

                Console.WriteLine(string.Format($"Obj methods: {strObj}, {objectInt.GetHashCode()}"));

                string first = "one";
                string second = "one two";
                
                Console.WriteLine(string.Format($"str methods: {string.Compare(first, second)}, {second.Contains(first)}, {second.Substring(4)}, {second.Insert(3, first)}"));

                string emptyStr = "";
                string nullStr = null;
                Console.WriteLine(string.Format($"string.IsNullOrEmpty: {string.IsNullOrEmpty(emptyStr)}, {string.IsNullOrEmpty(nullStr)}"));

                var variable = "";
                //variable = 5;

                int? nullable = null;
                Console.WriteLine(nullable == null);
               
                //2
                int two(int a, int b)
                {
                    return a + b;
                }
                Console.WriteLine(two(1, 2));

                var tupleF = ("Ыы", two: 5, 10.4);
                Console.WriteLine(string.Format($"Tuple: {tupleF.Item1}, {tupleF.two}"));

                int check = 0xFFFF;

                int chF(int a)
                {
                    return checked(a * a);
                }
                int unchF(int a)
                {
                    return (a * a);
                }

                Console.WriteLine(string.Format($"Checked: {chF(check)}"));

                using (Example tmp = new Example(10))
                {
                    Console.WriteLine(tmp.GetState());
                }

                    int x = Console.Read();
            }
        }
    }
}
