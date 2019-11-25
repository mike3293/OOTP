using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP9
{
    public static class StringHandler
    {
        internal static string RemoveS(string str, Program.test_delegate test_delegate) => test_delegate(str);      //удаление знаков
        public static void AddToString(string str, Action<string> test2) => test2(str);                 //добавление строки
        public static string RemoveSpase(string str, Func<string, string> test3) => test3(str);   //удаление пробелов
        public static string Upper(string str, Func<string, string> test4) => test4(str);        //в верхний регистр
        public static string Lower(string str, Func<string, string> test5) => test5(str);       //в нижний регистр
    }
}
