namespace OOP8
{
    interface IFunction<T> where T : struct
    {
        void Add(T element);
        void Remove(int pos);
        void Show();
    }
}
