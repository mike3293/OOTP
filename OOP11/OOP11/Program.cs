using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP11
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n;
            Console.Write("Enter string length n:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Months with a string length of " + n + ":");
            IEnumerable<string> length = from m in months
                                         where m.Length == n
                                         select m;
            foreach (string month in length)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("2. Summer and winter months:");
            IEnumerable<string> sumwin = months
                .Where(m =>
                m.Equals("December") || m.Equals("January") || m.Equals("February") ||
                m.Equals("June") || m.Equals("July") || m.Equals("August")
                );
            foreach (string month in sumwin)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("3. Months in alphabetical order:");
            IEnumerable<string> alph = months
                .OrderBy(m => m);
            foreach (string month in alph)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("4. Months containing a letter 'u' and a length >= 4:");
            IEnumerable<string> contU = months
                .Where(m => m.Contains('u') && m.Length >= 4);
            foreach (string month in contU)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine("\n---------------------------------------------------\n");


            Matrix mat1 = new Matrix(3, "first");
            Matrix mat2 = new Matrix(3, "second");
            Matrix mat3 = new Matrix(4, "third");
            Matrix mat4 = new Matrix(4, "four");
            Matrix mat5 = new Matrix(5, "fivth");
            Matrix mat6 = new Matrix(5, "sixth");

            Console.WriteLine(mat1);
            Console.WriteLine(mat2);
            Console.WriteLine(mat3);
            Console.WriteLine(mat4);
            Console.WriteLine("\n---------------------------------------------------\n");

            List<Matrix> list = new List<Matrix> { mat1, mat2, mat3, mat4 };

            //int max = list.Max(p => p.matrix.Cast<int>().Sum());

            //IEnumerable<Matrix> maxMatrix = list
            //    .Where(p => p.matrix.Cast<int>().Sum() == max);

            //Console.WriteLine("Max matrix:\n");
            //foreach (Matrix matrix in maxMatrix)
            //{
            //    Console.WriteLine(matrix);
            //}

            Matrix maxMatrix = list.Aggregate((m1, m2) =>
                m1.matrix.Cast<int>().Sum() > m2.matrix.Cast<int>().Sum() ? m1 : m2);

            Console.WriteLine("Max matrix:\n" + maxMatrix);

            IEnumerable<Matrix> N3 = list.Where(p => p.n == 3);
            Console.WriteLine("\nN3:\n");
            foreach (Matrix matrix in N3)
            {
                Console.WriteLine(matrix);
            }

            Console.WriteLine("\n---------------------------------------------------\n");

            Console.WriteLine("Own request:");
            IEnumerable<Matrix> own = list
                .Skip(1)
                .Where(p => p.n > 3)
                .OrderBy(p => p.Name)
                .Take(2)
                .Select(p => p);


            foreach (Matrix o in own)
            {
                Console.WriteLine(o);
            }

            List<Matrix> two = new List<Matrix> { mat4, mat5 };

            var join = two.Join(own, p => p.Name, t => t.Name, (p, t) => new { Name = p.Name, n = p.n });

            foreach (var o in join)
            {
                Console.WriteLine($"{o.Name} {o.n}");
            }

            Console.ReadKey();


        }
    }
}
