using System;

namespace OOP_5_6_7
{
    public class EmptyException : Exception
    {
        public EmptyException(string mess) : base(mess) { }
        public void GetInfo()
        {
            Console.WriteLine("EmptyException: " + this.Message);
            Console.WriteLine(this.StackTrace);
            Console.WriteLine(this.TargetSite);
        }
    }
    public class NoNameException : Exception
    {
        public NoNameException(string mess) : base(mess) { }
        public void GetInfo()
        {
            Console.WriteLine("NoNameException: " + this.Message);
            Console.WriteLine(this.StackTrace);
            Console.WriteLine(this.TargetSite);
        }
    }
    public class SecretException : Exception
    {
        public SecretException(string mess) : base(mess) { }
        public void GetInfo()
        {
            Console.WriteLine("SecretException: " + this.Message);
            Console.WriteLine(this.StackTrace);
            Console.WriteLine(this.TargetSite);
        }
    }
}
