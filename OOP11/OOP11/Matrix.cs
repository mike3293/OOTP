using System;

namespace OOP11
{
    internal class Matrix
    {
        public int[,] matrix;
        public int n;
        public string Name { get; set; }
        public static Random rand = new Random();
        public Matrix(int n, string name)
        {
            Name = name;
            this.n = n;
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(0, 3);
                }
            }
        }

        public override string ToString()
        {
            string tmp = Name + "\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmp += matrix[i, j] + " ";
                }
                tmp += "\n";
            }
            return tmp;
        }

    }
}
