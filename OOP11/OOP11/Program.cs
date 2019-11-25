using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IEnumerable<string> length = months
                .Where(p => (p.Length == n))
                .Select(p => p);
            foreach (string month in length)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("2. Summer and winter months:");
            IEnumerable<string> sumwin = months
                .Where(p => (p.Equals("December") || p.Equals("January") || p.Equals("February") || p.Equals("June") || p.Equals("July") || p.Equals("August")))
                .Select(p => p);
            foreach (string month in sumwin)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("3. Months in alphabetical order:");
            IEnumerable<string> alph = months
                .OrderBy(p => p)
                .Select(p => p);
            foreach (string month in alph)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("4. Months containing a letter 'u' and a length >= 4:");
            IEnumerable<string> contU = months
                .Where(p => (p.Contains('u') && p.Length >= 4))
                .Select(p => p);
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

            int max = list.Max(p => p.matrix.Cast<int>().Sum());

            IEnumerable<Matrix> maxMatrix = list
                .Where(p => p.matrix.Cast<int>().Sum() == max)
                .Select(p => p);

            foreach (Matrix matrix in maxMatrix)
            {
                Console.WriteLine(matrix);
            }

            IEnumerable<Matrix> N3 = list.Where(p => p.n == 3).Select(p => p);
            Console.WriteLine("N3: ");
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
