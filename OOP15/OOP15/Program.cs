using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace OOP15
{
    internal class Program
    {
        public static void ToWriteNum()
        {
            try
            {
                Console.WriteLine("Input n: ");
                int n = int.Parse(Console.ReadLine());
                using (StreamWriter sw = new StreamWriter("nums.txt"))
                {
                    for (int i = 0; i < n; i++)
                    {
                        sw.WriteLine(i);
                        Console.Write(i);
                        Thread.Sleep(100);
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Main(string[] args)
        {
            try
            {
                //1. Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет,
                //время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.
                using (StreamWriter sw = new StreamWriter("processes.txt"))
                {
                    Process[] allProcesses = Process.GetProcesses();    
                    foreach (Process p in allProcesses)         
                    {                                          
                        sw.WriteLine("ID: " + p.Id);
                        sw.WriteLine("Name: " + p.ProcessName);
                        sw.WriteLine("Priority: " + p.BasePriority);
                        sw.WriteLine("Responding: " + p.Responding);        
                        try
                        {
                            sw.WriteLine("Start at: " + p.StartTime);             //отсутствие доступа
                            sw.WriteLine("Total processor time: " + p.TotalProcessorTime);
                        }
                        catch
                        {
                            sw.WriteLine("NO ACESS FOR TIME");
                        }
                        sw.WriteLine();
                    }
                }


                //2. Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки, загруженные в домен.
                AppDomain domain = AppDomain.CurrentDomain;
                Console.WriteLine("Current domain");
                Console.WriteLine("Name: " + domain.FriendlyName);
                Console.WriteLine("Configuration: " + domain.SetupInformation);
                Console.WriteLine("Directory: " + domain.BaseDirectory);
                Console.WriteLine("Assemblies of current domain:");
                Assembly[] assemblies = domain.GetAssemblies();
                foreach (Assembly a in assemblies)
                {
                    Console.WriteLine(a.GetName().Name);
                }
                //Создайте новый домен.
                AppDomain newDomain = AppDomain.CreateDomain("New domain");
                //Загрузите туда сборку.
                newDomain.Load(new AssemblyName("OOP15"));
                Console.WriteLine("Name of the new domain: " + newDomain.FriendlyName + "\nAssamblies of new domain:");
                foreach (Assembly a in newDomain.GetAssemblies())
                {
                    Console.WriteLine(a.GetName().Name);
                }
                //Выгрузите домен.
                AppDomain.Unload(newDomain);
                Console.WriteLine("\nPress any key");
                Console.ReadKey();


                //3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для задержки)
                //и записи в файл и на консоль простых чисел от 1 до n(задает пользователь).
                //Вызовите методы управления потоком(запуск, приостановка, возобновление и тд.) 
                //Во время выполнения выведите информацию о статусе потока, имени, приоритете, числовой идентификатор и т.д.
                Console.WriteLine("Threads");                         
                Thread thread = new Thread(new ThreadStart(ToWriteNum));                 
                thread.Start();                                         
                thread.Name = "MyThread01";
                Thread.Sleep(2000);
                thread.Suspend();
                Console.WriteLine("\nThread name: " + thread.Name);
                Console.WriteLine("State: " + thread.ThreadState);
                Console.WriteLine("Priority: " + thread.Priority);
                thread.Resume();
                Thread.Sleep(2000);

                Console.WriteLine("\nPress any key");
                Console.ReadKey();


                //4. Создайте два потока.Первый выводит четные числа, второй нечетные до n и
                //записывают их в общий файл и на консоль.Скорость расчета чисел у потоков – разная.
                //a.Поменяйте приоритет одного из потоков.
                //b.Используя средства синхронизации организуйте работу потоков, таким образом, чтобы
                //i. выводились сначала четные, потом нечетные числа
                Console.WriteLine("Chet/Nechet");
                Console.WriteLine("Consistently:");
                TwoThreads.Consistently();
                Thread.Sleep(4000);
                Console.WriteLine("\nPress any key\n");
                Console.ReadKey();
                //ii. последовательно выводились одно четное, другое нечетное.
                Console.WriteLine("One by one:");
                TwoThreads.OneByOne();

                Thread.Sleep(7000);
                Console.WriteLine("\nPress any key\n");
                Console.ReadKey();


                //5. Придумайте и реализуйте повторяющуюся задачу на основе класса Timer
                TimerCallback tm = new TimerCallback(Count);
                Timer timer = new Timer(tm, null, 500, 1000);
                Thread.Sleep(5000);
                Console.WriteLine("Time is over...");
                timer.Dispose();
                Console.ReadKey();
                void Count(object obj)
                {
                    Console.WriteLine($"It's {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
