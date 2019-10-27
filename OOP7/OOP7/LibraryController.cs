using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    public class LibraryController
    {
        public void ShowFromYear(Library lib, int y) { lib.ShowFromYear(y); }
        public int Count(Library lib) { return lib.CountOfBooks(); }
        public double Cost(Library lib) { return lib.CostOfBooks(); }
    }
}
