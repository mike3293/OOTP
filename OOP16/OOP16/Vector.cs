﻿using System;
using System.Collections.Generic;

namespace OOP16
{
    public class Vector
    {
        private Random random = new Random();
        public List<int> vector = new List<int>();
        public Vector(int n)
        {
            for (int i = 0; i < n; i++)
            {
                vector.Add(random.Next(n));
            }
        }
        public int Length => vector.Count;
        public int this[int num]
        {
            get => vector[num];
            set => vector[num] = value;
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 1; i < vector.Count; i++)
            {
                sum += vector[i];
            }
            return sum;
        }
        public void Sort()
        {
            vector.Sort();
        }
        public static Vector operator *(Vector vec, int n)
        {
            for (int i = 0; i < vec.vector.Count; i++)
            {
                vec.vector[i] *= n;
            }
            return vec;
        }
    }
}

