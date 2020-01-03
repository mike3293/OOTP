using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace OOP16
{
    public static class VectorController
    {
        //1.Используя TPL создайте длительную по времени задачу(на основе Task) на выбор:
        //умножение вектора размера 100000 на число
        public static void GetTask(int size, int num)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Vector vector = new Vector(size);
            Task task = Task.Factory.StartNew(() => vector = vector * num);
            //1) Выведите идентификатор текущей задачи, проверьте во время выполнения – завершена ли задача и выведите ее статус. 
            Console.WriteLine("ID: " + task.Id + "\nStatus: " + task.Status);
            task.Wait();
            stopwatch.Stop();
            //2) Оцените производительность выполнения используя объект Stopwatch на нескольких прогонах.
            Console.WriteLine(stopwatch.Elapsed);
        }

        //2. Реализуйте второй вариант этой же задачи с токеном отмены CancellationToken и отмените задачу.
        public static void GetTaskWitchCancelation(int size, int num)
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            Vector vector = new Vector(size);
            Task task = new Task(() => vector = vector * num, cancellationToken.Token);
            task.Start();
            cancellationToken.Cancel(); //отменяем задачи
            Thread.Sleep(500);
            Console.WriteLine("\nStatus: " + task.Status);
        }

        //3.Создайте три задачи с возвратом результата и используйте их для выполнения четвертой задачи. Например, расчет по формуле.
        public static async Task Sum(Vector first, Vector second, Vector third)
        {
            Task<int> task1 = new Task<int>(() => first.Sum());
            task1.Start();
            Task<int> task2 = new Task<int>(() => second.Sum());
            task2.Start();
            Task<int> task3 = new Task<int>(() => third.Sum());
            task3.Start();
            Task<Vector> task4 = new Task<Vector>(() => new Vector(task1.Result + task2.Result + task3.Result));
            //4.Создайте задачу продолжения(continuation task) в двух вариантах:
            //1) C ContinueWith -планировка на основе завершения множества предшествующих задач
            Task task5 = task4.ContinueWith(t => Console.WriteLine("\n---continuation---"));
            task4.Start();
            await task5;
            Console.WriteLine("Result of the sum: " + task4.Result.Sum());
        }
    }
}
