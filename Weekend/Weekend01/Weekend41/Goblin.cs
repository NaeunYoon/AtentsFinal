using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weekend41;

namespace Monster
{
     class Goblin : Monster
    {
        public Goblin(string name, int health, int defense, int attack) 
            : base(name, health, defense, attack)
        {

        }

        public override void GetDamage(int attack)
        {
            Console.WriteLine("일반적인 몬스터의 getDamage 함수");
            Health -= attack - defense;
        }

    }
}
