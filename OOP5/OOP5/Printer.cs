﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    class Printer
    {
        public static void IAmPrinting(Person someone)
        {
            Console.WriteLine(someone.ToString());
        }
    }
}
