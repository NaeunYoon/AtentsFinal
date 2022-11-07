
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    class Slaim : Monster
    {

        private int _physicalRegist;

        public int PhysicalRegist
        {
            get
            {
                return _physicalRegist;
            }
        }

        public Slaim(string name, int health, int defense, int attack, int physicalRegist)  
            : base(name,health,defense,attack)
        {
            _physicalRegist = physicalRegist;
        }

        public override void GetDamage(int attack)   //부모의 가상메서드를 재정의
        {
            Console.WriteLine("슬라임 몬스터의 getDamage 함수");
             Health -= attack-(defense-PhysicalRegist);

        }

        public new void Info()  //부모의 정보를 덮었으니 new 해준다
        {
            base.Info();
            Console.WriteLine($"물리저항력 :{_physicalRegist}\n");
        }
    }
}

