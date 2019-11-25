using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1
{
    //2
    public class Car : ICloneable
    {
        public string Color { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }

        public Car(string color, string model, int num)
        {
            Color = color;
            Model = model;
            Number = num;
        }

        public object Clone()
        {
            Car carOut = new Car(Color, Model, Number);
            return carOut;
        }
    }


    //3


    internal class Junior
    {
        public virtual void work()
        {
            Console.WriteLine("Junior working");
        }
    }

    internal class Middle : Junior
    {
        public override void work()
        {
            Console.WriteLine("Middle working");
        }
    }

    internal class God : Junior
    {
        public override void work()
        {
            Console.WriteLine("God did all job");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"from {float.MinValue} to {float.MaxValue}");
            string str = "1234567";
            Console.WriteLine(str.Substring(4, 1));

            int[,] array = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                    {
                        array[i, j] = 1;
                    }
                    else
                    {
                        array[i, j] = 0;
                    }
                    Console.Write(array[i, j]);
                    if (j == 7)
                    {
                        Console.Write('\n');
                    }
                }
            }


            //2

            Car car1 = new Car("blue", "bmw", 1234);
            Car car2 = (Car)car1.Clone();
            Car car3 = (Car)car1.Clone();

            car1.Number = 3214;
            car3.Color = "red";

            Console.WriteLine($"Number: {car1.Number} Model: {car1.Model} Color: {car1.Color}");
            Console.WriteLine($"Number: {car2.Number} Model: {car2.Model} Color: {car2.Color}");
            Console.WriteLine($"Number: {car3.Number} Model: {car3.Model} Color: {car3.Color}");


            //3

            Junior jun = new Junior();
            Middle mid = new Middle();
            God god = new God();

            Junior[] arrayObj = new Junior[] { jun, mid, god };

            arrayObj[2].work();

            Console.ReadKey();
        }
    }
}
