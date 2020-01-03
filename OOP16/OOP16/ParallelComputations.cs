using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OOP16
{
    internal class ParallelComputations
    {
        //5.Используя Класс Parallel распараллельте вычисления циклов For(), ForEach().
        //Например, на выбор: генерация нескольких массивов по 1000000 элементов. 
        //Оцените производительность по сравнению с обычными циклами
        public static void For()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                Generate();    //обычный цикл
                Vector vec = new Vector(10000);
                vec[0] += 1;
            }
            stopwatch.Stop();
            Console.WriteLine("\nFor:\nCommon cycle: " + stopwatch.Elapsed);
            stopwatch.Start();
            Parallel.For(1, 10000, GenerateParallel);
            stopwatch.Stop();
            Console.WriteLine("Parallel cycle: " + stopwatch.Elapsed);
        }

        public static void ForEach()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int v in new List<int>(100000000))
            {
                CheckForEach(v);
            }
            stopwatch.Stop();
            Console.WriteLine("\nForEach:\nCommon cycle: " + stopwatch.Elapsed);
            stopwatch.Start();
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>(100000000), CheckForEach);
            stopwatch.Stop();
            Console.WriteLine("Parallel cycle: " + stopwatch.Elapsed);
        }

        public static void Generate()
        {
            for (int i = 0; i < 100000;)
            {
                i++;
            }
        }


        private static int _result = 0;

        public static void GenerateParallel(int n)
        {
            _result += 1;
            Vector vec = new Vector(10000);
            vec[0] += 1;
        }

        public static void CheckForEach(int n)
        {
            _result += n + 1;
        }

        //6.Используя Parallel.Invoke() распараллельте выполнение блока операторов.
        public static void ParallelInvoke()
        {
            Parallel.Invoke(
                For,
                ForEach
            );
        }
    }
}
