namespace OOP_5_6
{
    public class LibraryController
    {
        public void ShowFromYear(Library lib, int y) { lib.ShowFromYear(y); }
        public int Count(Library lib) { return lib.CountOfBooks(); }
        public double Cost(Library lib) { return lib.CostOfBooks(); }
    }
}
