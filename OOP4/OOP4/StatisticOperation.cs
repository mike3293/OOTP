using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public static class StatisticOperation
    {

        public static string sum(MyList list)
        {
            string sumstring = "";
            foreach (string item in list)
            {
                sumstring += item;
            }
            return sumstring;
        }

        public static int diff(MyList list)
        {
            int min = int.MaxValue;
            int max = list[0].Length;
            foreach (string item in list)
            {
                if (item.Length < min)
                {
                    min = item.Length;
                }

                if (item.Length > max)
                {
                    max = item.Length;
                }
            }
            return max - min;
        }

        public static int count(MyList list)
        {
            int counter = 0;
            foreach (string item in list)
            {
                counter++;
            }

            return counter;
        }

        public static string MaxWord(this MyList list)
        {
            int maxLength = 0;
            string maxStr = "";
            foreach (string item in list)
            {
                if (item.Length > maxLength)
                {
                    maxStr = item;
                    maxLength = item.Length;
                }

            }
            return maxStr;
        }

        public static MyList DelLast(this MyList list)
        {
            list.RemoveAt(list.Count - 1);
            return list;
        }

    }
}
