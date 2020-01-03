using System;

namespace OOP9
{
    public class Game
    {
        public string name;
        public int health;
        public Game()
        {
            name = "NoName";
            health = 100;
        }
        public Game(string name, int health)
        {
            this.name = name;
            this.health = health;
        }
        public event EventHandler<ActArgs> Attack;      //события на основе стандартного делегата
        public event EventHandler<ActArgs> Treatment;
        public void ToAtt()    //метод, инициирующий событие
        {
            Console.WriteLine(name + ", you have been attacked.");
            Attack?.Invoke(this, new ActArgs(health));   //вызов события, если не null
        }
        public void ToTr()
        {
            Console.WriteLine(name + ", you have been treated.");
            Treatment?.Invoke(this, new ActArgs(health));
        }
    }

    public class ActArgs : EventArgs  //класс, содержащий инф. о событиях
    {
        private int _h;
        public ActArgs(int h)
        {
            _h = h;
        }
        public void ToAttack()  //метод-обработчик события
        {
            int heal = _h;
            _h -= 10;
            if (_h <= 0)
            {
                Console.WriteLine("You are dead (*o*)");
            }
            else
            {
                Console.WriteLine("Health level dropped from {0} to {1}!", heal, _h);
            }
        }
        public void ToTreat()
        {
            _h += 20;
            if (_h > 100) { _h = 100; }
            Console.WriteLine("Now the level of health is {0}.", _h);
        }
    }
}
