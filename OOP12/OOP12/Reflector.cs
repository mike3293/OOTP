using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP12
{
    public class Reflector
    {
        public Type type;
        public Reflector(string type)
        {
            this.type = Type.GetType(type); //получаем объект Type
        }
        //a.выводит всё содержимое класса в текстовый файл;
        public void AboutClass()
        {
            using (FileStream fstream = new FileStream("class.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (MemberInfo info in type.GetMembers())
                {
                    sw.WriteLine(info.DeclaringType + " - " + info.MemberType + " - " + info.Name + "\n");
                }                   //класс                  //тип члена класса         //имя члена класса
                sw.Close();
            }
        }

        public void PublicMethods()
        {
            Console.WriteLine("Public methods:");
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.IsPublic)    //если публичный, то выводит
                {
                    Console.WriteLine(method.Name);
                }
            }
        }

        public void Fields()
        {
            Console.WriteLine("\nFields and Properties:");
            foreach (FieldInfo field in type.GetFields())
            {
                Console.WriteLine(field.Name + " - " + field.FieldType);
            }
            foreach (PropertyInfo prorertie in type.GetProperties())
            {
                Console.WriteLine(prorertie.Name + " - " + prorertie.PropertyType);
            }
        }

        public void Interfaces()
        {
            Console.WriteLine("\nInterfaces:");
            foreach (Type interfaces in type.GetInterfaces())
            {
                Console.WriteLine(interfaces.Name);
            }
        }

        public void MethodByType(Type parameterType)
        {
            MethodInfo[] methods = type.GetMethods();
            IEnumerable<MethodInfo> result = methods.Where(a => a.GetParameters().Where(t => t.ParameterType == parameterType).Count() != 0);
            Console.WriteLine($"All methods with type of parameter {parameterType.Name}: ");
            foreach (MethodInfo el in result)
            {
                Console.WriteLine(el.Name);
            }
        }
        public void ExecuteMethod(string method)
        {
            Console.WriteLine("\nMethods {0} with parameter from file:", method);
            FileStream fstream = new FileStream("param.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fstream);
            object[] str = { sr.ReadLine() };

            MethodInfo currentMethodInfo = type.GetMethod(method);
            currentMethodInfo.Invoke(null, str);   //вызываем метод экземпляра test с параметром obj1
            //Console.WriteLine(result);
        }
    }
}
