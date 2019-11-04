using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine(this.name + ", you have been attacked.");
            Attack?.Invoke(this, new ActArgs(this.health));//вызов события, если не null
        }
        public void ToTr()
        {
            Console.WriteLine(this.name + ", you have been treated.");
            Treatment?.Invoke(this, new ActArgs(this.health));
        }
    }

    public class ActArgs : EventArgs  //класс, содержащий инф. о событиях
    {
        int h;
        public ActArgs(int h)
        {
            this.h = h;
        }
        public void ToAttack()  //метод-обработчик события
        {
            int heal = h;
            h -= 10;
            if (h <= 0)
            {
                Console.WriteLine("You are dead (*o*)");
            }
            else
            {
                Console.WriteLine("Health level dropped from {0} to {1}!", heal, h);
            }
        }
        public void ToTreat()
        {
            h += 20;
            if (h > 100) { h = 100; }
            Console.WriteLine("Now the level of health is {0}.", h);
        }
    }
}
