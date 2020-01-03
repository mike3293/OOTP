using System;
using System.Linq;

namespace OOP9
{
    internal class Program
    {
        private static void User_Treatment(object sender, ActArgs e)
        {
            e.ToTreat();    //обработчик события
        }

        private static void User_Attack(object sender, ActArgs e)
        {
            e.ToAttack();   //обработчик события
        }

        public delegate string test_delegate(string str);

        private static void Main(string[] args)
        {
            Console.WriteLine("------------------Game------------------");
            Game user1 = new Game("Tonny", 30);
            Game user2 = new Game("Jack", 20);
            Game user3 = new Game();
            Console.WriteLine("\nUser1");
            user1.Attack += User_Attack;    //подписываем объект на событие Атака
            user1.Attack += User_Attack;
            user1.Attack += User_Attack;
            user1.ToAtt();
            Console.WriteLine("\nUser2");
            user2.Treatment += User_Treatment;  //подписываем объект на событие Лечение
            user2.ToTr();
            Console.WriteLine("\nUser3");
            user3.Treatment += User_Treatment;
            user3.ToTr();
            user3.Attack += User_Attack;
            user3.ToAtt();

            Console.WriteLine("\n\n--------------Работа со строками--------------");
            string str = "P! o, I          ?       .t 4";
            Action<string> test2;       //не возвр значений
            Func<string, string> test3;
            Func<string, string> test4;
            Func<string, string> test5;
            string test(string str1)
            {
                char[] sign = { '.', ',', '!', '?', '-', ':' };
                for (int i = 0; i < str1.Length; i++)
                {
                    if (sign.Contains(str1[i]))
                    {
                        str1 = str1.Remove(i, 1);
                    }
                }
                Console.WriteLine(str1);
                return str1;
            };
            test_delegate tmp = null;
            tmp += test;
            test2 = delegate (string str2)   //анонимный метод(безямынный блок кода)
            {
                str2 += " 2 part";
                Console.WriteLine(str2);
            };
            test3 = str3 =>
            {
                str3 = str3.Replace(" ", string.Empty);
                Console.WriteLine(str3);
                return str3;
            };
            test4 = str4 =>
            {
                str4 = str4.ToUpper();
                Console.WriteLine(str4);
                return str4;
            };
            test5 = str5 =>
            {
                str5 = str5.ToLower();
                Console.WriteLine(str5);
                return str5;
            };
            Console.WriteLine("Строка до: " + str);
            Console.WriteLine("Строки после: ");
            string s1, s2, s3;
            s1 = StringHandler.RemoveS(str, tmp);
            StringHandler.AddToString(s1, test2);
            s2 = StringHandler.RemoveSpase(s1, test3);
            s3 = StringHandler.Upper(s2, test4);
            StringHandler.Lower(s3, test5);

            Console.ReadKey();
        }

    }
}
