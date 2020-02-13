using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warrior_Game.Enum;
using Warrior_Game.Equipment;

namespace Warrior_Game
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH=20;
        private const int BAD_GUY_STARTING_HEALTH=20;

        private readonly Faction FACTION;
        private int health;
        private bool isAlive;
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
        }

        private string name;
        private Weapon weapon;
        private Armor armor;
        public Warrior (string name , Faction faction)
        {
            this.name = name;
            this.FACTION = faction;
            this.isAlive = true;


            switch (faction )
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }
        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoint;
            enemy.health -= damage;
            AttackResult(enemy, damage);
        }

        private void AttackResult(Warrior enemy, int damage)
        {
            if (enemy.health < 0)
            {
                enemy.isAlive = false;
                Tools.ColorfullWriteLine($"{enemy.name}is dead!", ConsoleColor.Red);
                Tools.ColorfullWriteLine($"{ name } is victory !!!", ConsoleColor.Green);

                Console.ReadLine();

            }
            else
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} damage was inflicted to {enemy.name}, Remaining helth is {enemy.health} ");
            }
        }
    }
}
