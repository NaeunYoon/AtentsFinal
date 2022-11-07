using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    class Ogre : Monster
    {
 
        public Ogre(string name, int health, int defense, int attack) 
            : base (name, health, defense, attack)    
        {

        }
        public override void GetDamage(int attack)
        {
            Console.WriteLine("일반적인 몬스터의 getDamage 함수");
            Health -= attack - defense;
        }


    }

}
