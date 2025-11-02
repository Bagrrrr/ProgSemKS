using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Character> ArmyOne = new List<Character>();
            List<Character> ArmyTwo = new List<Character>();
            Character a = new Warrior("beda");
            Character g = new Wizard("beda");
            Character h = new Archer("beda");
            ArmyOne.Add(a);
            ArmyOne.Add(a);
            ArmyOne.Add(a);
            ArmyOne.Add(a);
            ArmyOne.Add(g);
            ArmyOne.Add(g);
            ArmyOne.Add(g);
            ArmyOne.Add(h);
            ArmyOne.Add(h);
            ArmyOne.Add(h);

            ArmyTwo.Add(a);
            ArmyTwo.Add(a);
            ArmyTwo.Add(a);
            ArmyTwo.Add(a);
            ArmyTwo.Add(a);
            ArmyTwo.Add(g);
            ArmyTwo.Add(g);
            ArmyTwo.Add(g);
            ArmyTwo.Add(h);
            ArmyTwo.Add(h);

        }
        abstract class Character
        {
            public Character(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
            public int Health { get; set; }
            public int Power { get; set; }
            
            public string Hlaska { get; set; }

            protected void Attack(Character target)
            {
                target.Health -= Power;
                Console.WriteLine(Hlaska);
            }
            public bool IsAlive(Character target)
            {
                if (target.Health <= 0)
                {
                    return false;
                }
                else return true;
            }

        }
        class Warrior : Character
        {
            public Warrior(string name) : base(name)
            {
                Health = 21;
                Power = 4;
                Hlaska = "AARGH";
            }
        }
        class Wizard : Character
        {
            public Wizard(string name) : base(name)
            {
                Health = 16;
                Power = 4;
                Hlaska = "Fajrbol";
            }
            public void TakeDamage(Character attacker)
            {
                attacker.Health -= (attacker.Power) / 2;
            }
        }
        class Archer : Character
        {
            public Archer(string name) : base(name)
            {
                Health = 13;
                Power = 6;
                Hlaska = "Pew";
            }
            
        }

    }
}
