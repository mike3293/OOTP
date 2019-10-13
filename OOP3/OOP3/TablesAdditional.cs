using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableNS
{
    public partial class Table
    {
        private int _legs;

        public readonly double price; 

        private static string type;

        public int Legs
        {
            get
            {
                return _legs;
            }
            set
            {
                if (value > 0)
                    _legs = value;
            }
        }

        public string Name { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        public int AllDimensions
        {
            
            set
            {
                if (value >= 0)
                    Height = Width = Depth = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
        }


        public static void showType(out string typeToReturn)
        {
            Console.WriteLine($"Class type: {type}");
            typeToReturn = type;
        }
    }
}
