using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    abstract class Monster
    {
        private string _name;   // 이름
        private int _health;    // 생명력
        private int _defense;   // 방어력
        private int _attack;    // 공격력

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                _health = value;
            }
        }

        public int defense
        {
            get
            {
                return _defense;
            }
        }

        public Monster(string name, int health, int defense, int attack)
        {
            _name = name;
            _health = health;
            _defense = defense;
            _attack = attack;
        }

        public void Attack(Monster enemy)
        {
            Console.WriteLine("attack ( monster enemy)");

            enemy._health = enemy._health - (_attack - enemy._defense);
            enemy.GetDamage(_attack);
            Console.WriteLine($"{_name}이 {enemy._name}을 공격해서 " +
                                $"생명력을 {enemy._health}로 줄였음\n");
        }

        //public void Attack(Slaim enemy) //물리저항력을 포함한 슬라임을 위한 함수 따로 제작
        //{
        //    Console.WriteLine("attack ( slaim enemy)");

        //    enemy._health -= enemy._health - (_attack - enemy._defense - enemy.PhysicalRegist);
        //    enemy.GetDamage(_attack);

        //    Console.WriteLine($"{_name}이 {enemy._name}을 공격해서 " +
        //                        $"생명력을 {enemy._health}로 줄였음\n");
        //}





        /// <summary>
        /// 데미지 처리 함수
        /// </summary>
        /// <param name="attack"></param>
        //public virtual void GetDamage(int attack)   // 
        //{
        //    Console.WriteLine("일반적인 몬스터의 getDamage 함수");
        //    Health -= attack - defense;

        //}


        public abstract void GetDamage(int attack);
        //추상클래스로 만들어줘야 함
        //추상클래스는 자기 자신의 객체를 생성할 수 없지만 자신의 추상 메소드를
        //자식들이 상속받을 때 만들도록 강제할 수 있다


        public void Defense()
        {

        }

        public void Run()
        {

        }

        public void Info()
        {
            Console.WriteLine($"이름: {_name}\n생명력:{_health}\n" +
                              $"방어력:{_defense}\n공격력:{_attack}\n");
        }

    }
}