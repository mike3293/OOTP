using System;
using System.IO;
using System.Threading;

namespace OOP15
{
    internal static class TwoThreads
    {
        public static void Consistently()                          
        {
            object locker = new object();                          
            if (File.Exists("ch_nech.txt"))
            {
                File.Delete("ch_nech.txt");
            }
            Thread CheT = new Thread(new ThreadStart(Chet));
            Thread NecheT = new Thread(new ThreadStart(Nechet))
            {
                Priority = ThreadPriority.AboveNormal
            };
            CheT.Start();
            NecheT.Start();

            void Chet()
            {
                lock (locker)             
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i + " ch");
                            WriteResultToFile(i);
                            Thread.Sleep(300);

                        }
                    }
                }
            }
            void Nechet()
            {
                lock (locker)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i + " n");
                            WriteResultToFile(i);
                            Thread.Sleep(500);

                        }
                    }
                }
            }
            void WriteResultToFile(int data)
            {
                StreamWriter sw = new StreamWriter("ch_nech.txt", true);
                sw.WriteLine(data);
                sw.Close();
            }
        }



        public static void OneByOne()
        {
            Mutex mutex = new Mutex();
            if (File.Exists("ch_n_ch.txt"))
            {
                File.Delete("ch_n_ch.txt");
            }
            Thread CheT = new Thread(new ThreadStart(Chet));
            Thread NecheT = new Thread(new ThreadStart(Nechet));
            CheT.Start();
            NecheT.Start();

            void Chet()
            {
                for (int i = 0; i < 10; i++)
                {
                    mutex.WaitOne();   
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i + " ch");
                        WriteResultToFile(i);
                        Thread.Sleep(300);
                    }
                    mutex.ReleaseMutex(); 
                }
            }
            void Nechet()
            {
                for (int i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    if (i % 2 != 0)
                    {
                        Console.WriteLine(i + " n");
                        WriteResultToFile(i);
                        Thread.Sleep(500);
                    }
                    mutex.ReleaseMutex();
                }
            }
            void WriteResultToFile(int data)
            {
                StreamWriter sw = new StreamWriter("ch_n_ch.txt", true);
                sw.WriteLine(data);
                sw.Close();
            }
        }
    }
}
