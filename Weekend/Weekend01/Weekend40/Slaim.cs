using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    class Slaim
    {
        private string _name;
        private int _health;
        private int _defense;
        private int _attack;
        private int _physicalRegist;

        public string NAME
        {
            get { return _name; }
        }

        public int HEALTH
        {
            get { return _health; }
            set
            {
                if (value >= 0)
                {
                    Console.WriteLine("사망");
                }
                _health = value;
            }
        }

        public int DEFENSE
        {
            get { return _defense; }
            set { _defense = value; }
        }
        public int PhysicalRegist
        {
            get
            {
                return _physicalRegist;
            }
        }

        public Slaim(string name, int health, int defense, int attack, int physicalRegist)   //오우거 생성자
        {
            _name = name;
            _health = health;
            _defense = defense;
            _attack = attack;
            _physicalRegist = physicalRegist;
        }

        public void Attack(Ogre enemy)
        {
            enemy.HEALTH = _attack - (_health - enemy.DEFENSE);
            Console.WriteLine($"{_name}이 {enemy.NAME}을 공격해서 생명력이 {enemy.HEALTH}로 줄었음");
        }

        public void Attack(Slaim enemy)
        {
            enemy._health -= (_attack - enemy._defense - enemy._physicalRegist);

            Console.WriteLine($"{_name}이 {enemy._name}을 공격해서 생명력을 {enemy._health}로 줄였음\n");
        }

        public void Attack(Dragon enemy)
        {
            enemy.HEALTH -= _attack - enemy.DEFENSE;
            Console.WriteLine($"{NAME}이 {enemy.NAME}을 공격해서 생명력이 {enemy.HEALTH}로 줄음");
        }

        public void Attack(NAEUN enemy)
        {
            enemy.HEALTH -= _attack - enemy.DEFENSE;
            Console.WriteLine($"{NAME}이 {enemy.NAME}을 공격해서 생명력이 {enemy.HEALTH}로 줄음");
        }

        public void Info()
        {
            Console.WriteLine($"이름 :{_name} \n생명력 :{_health} \n방어력 :{_defense} \n공격력 :{_attack} \n물리저항력 :{_physicalRegist}\n");
        }
    }
}

