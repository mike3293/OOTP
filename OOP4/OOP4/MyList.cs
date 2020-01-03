using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{

    public class MyList : List<string>
    {
        public class Owner
        {
            public int id;
            public string name;
            public string organization;

            public Owner(int id, string name, string organization)
            {
                this.id = id;
                this.name = name;
                this.organization = organization;
            }
        }

        public class Date
        {
            private DateTime dateTime = DateTime.Now;

            public override string ToString()
            {
                return dateTime.ToShortDateString();
            }
        }


        public static MyList operator +(MyList a, (string item, int index) tuple)
        {
            a.Insert(tuple.index, tuple.item);
            return a;
        }

        public static MyList operator >>(MyList a, int index)
        {
            a.RemoveAt(index);
            return a;
        }

        public static bool operator ==(MyList a, MyList b)
        {
            bool flag = true;

            if (a.Count != b.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] != b[i])
                    {
                        flag = false;
                    }
                }
                return flag;
            }
        }

        public static bool operator !=(MyList a, MyList b)
        {
            bool flag = true;

            if (a.Count != b.Count)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] != b[i])
                    {
                        flag = false;
                    }
                }
                return !flag;
            }
        }

        public override string ToString()
        {
            string all = "";
            foreach (string str in this)
            {
                all += str + " ";
            }
            return all;
        }

    }

}

