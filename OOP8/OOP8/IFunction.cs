using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP8
{
    //Создайте обобщенный интерфейс с операциями добавить, удалить, просмотреть.
    interface IFunction<T> where T : struct
    {
        void Add(T element);
        void Remove(int pos);
        void Show();
    }
}
