using System;

namespace OOP12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Reflector reflector = new Reflector("OOP5.Author");
            reflector.AboutClass();
            reflector.PublicMethods();
            reflector.Fields();
            reflector.Interfaces();

            reflector.MethodByType(typeof(int));
            reflector.ExecuteMethod("PersonSay");
            Console.ReadKey();
        }
    }
}
