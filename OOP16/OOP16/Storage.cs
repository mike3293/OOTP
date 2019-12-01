using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP16
{
    public static class Storage
    {
        public static void Work()
        {
            BlockingCollection<int> appliances = new BlockingCollection<int>();
            Thread tprod = new Thread(() => AllProd());
            Thread tcust = new Thread(() => AllCust());
            tprod.Start();
            tcust.Start();
            void AllProd()
            {
                Task.Run(() => Provider(ref appliances, 1000, 1));
                Task.Run(() => Provider(ref appliances, 900, 2));
                Task.Run(() => Provider(ref appliances, 200, 3));
                Task.Run(() => Provider(ref appliances, 700, 4));
                Task.Run(() => Provider(ref appliances, 100, 5));
            }
            void AllCust()
            {
                Task.Run(() => Customer(ref appliances, 100));
                Task.Run(() => Customer(ref appliances, 500));
                Task.Run(() => Customer(ref appliances, 3000));
                Task.Run(() => Customer(ref appliances, 300));
                Task.Run(() => Customer(ref appliances, 400));
                Task.Run(() => Customer(ref appliances, 230));
                Task.Run(() => Customer(ref appliances, 100));
                Task.Run(() => Customer(ref appliances, 423));
                Task.Run(() => Customer(ref appliances, 110));
                Task.Run(() => Customer(ref appliances, 600));
            }
        }

        public static void Provider(ref BlockingCollection<int> blockingCollection, int timeMs, int id)
        {
            Thread.Sleep(timeMs);
            blockingCollection.Add(id);
            int[] a = blockingCollection.ToArray();
            string tmp = $"+{id} Storage: ";
            for (int z = 0; z < a.Length; z++)
            {
                tmp += $"{a[z]} ";
            }
            Console.WriteLine(tmp);
            
        }

        public static void Customer(ref BlockingCollection<int> blockingCollection, int timeMs)
        {
            Thread.Sleep(timeMs);
            if (blockingCollection.Count != 0)
            {
                int i;
                blockingCollection.TryTake(out i);
                string tmp = $"-{i} Storage: ";

                int[] a = blockingCollection.ToArray();
                for (int z = 0; z < a.Length; z++)
                {
                    tmp += $"{a[z]} ";
                }
                Console.WriteLine(tmp);
            }
            

            else { Console.WriteLine("customer leave"); }
            
        }
    }
}
