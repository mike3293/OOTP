using System;

namespace OOP16
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            VectorController.GetTask(100000000, 11);
            //VectorController.GetTask(100000000, 75);
            //VectorController.GetTask(100000000, 202);
            VectorController.GetTaskWitchCancelation(100000000, 90);

            VectorController.Sum(new Vector(2), new Vector(20), new Vector(30)).GetAwaiter().GetResult();

            //5.Используя Класс Parallel распараллельте вычисления циклов For(), ForEach().
            ParallelComputations.For();
            ParallelComputations.ForEach();

            //6.Используя Parallel.Invoke() распараллельте выполнение блока операторов.
            ParallelComputations.ParallelInvoke();

            //7.Используя Класс BlockingCollection реализуйте следующую задачу:
            //Есть 5 поставщиков бытовой техники, они завозят уникальные товары на склад(каждый по одному) и 10 покупателей – покупают все подряд,
            //если товара нет - уходят.В вашей задаче: cпрос превышает предложение.Изначально склад пустой.
            //У каждого поставщика своя скорость завоза товара.Каждый раз при изменении состоянии склада выводите наименования товаров на складе.
            Storage.Start();

            Console.ReadKey();
        }
    }
}
