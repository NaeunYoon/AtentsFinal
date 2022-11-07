using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend39
{

    class Dragon
    {
        private string _name;
        private int _health;
        private int _defense;
        private int _attack;

        public string NAME
        {
            get { return _name; }
        }

        public int HEALTH
        {
            get { return _health; }
            set {
                if (value <= 0)
                {
                    Console.WriteLine("사망");
                }
                _health = value; }
        }
        public int DEFENSE
        {
            get { return _defense; }
        }
        public int ATTACK
        {
            get { return _attack; }
            set { _attack = value; }
        }

        public Dragon(string name, int health, int defense, int attack)
        {
            _name = name;
            _health = health;
            _defense = defense;
            _attack = attack;
        }

        public void Attack(Dragon enemy)
        {
            enemy._health = enemy._health - (_attack - enemy._defense);

            Console.WriteLine($"{_name}이 {enemy._name}을 공격해서 생명력이 {enemy._health}로 줄었음");
        }
        public void Attack(Ogre enemy)
        {
            enemy.HEALTH -= _attack - enemy.DEFENSE;
            Console.WriteLine($"{NAME}이 {enemy.NAME}을 공격해서 생명력이 {enemy.HEALTH}로 줄음");
        }

        public void Attack(NAEUN enemy)
        {
            enemy.HEALTH -= _attack - enemy.DEFENSE;
            Console.WriteLine($"{NAME}이 {enemy.NAME}을 공격해서 생명력이 {enemy.HEALTH}로 줄음");
        }

        public void Defense()
        {

        }


        public void Info()
        {
            Console.WriteLine($"이름 :{_name} \n생명력 :{_health} \n방어력 :{_defense} \n공격력 :{_attack}");
        }
    }


    class NAEUN
    {
        private string _name;
        private int _health;
        private int _defense;
        private int _attack;

        public string NAME
        {
            get { return _name; }
            set { _name = value; }
        }

        public int HEALTH
        {
            get { return _health; }
            set
            {
                if (value <= 0)
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

        public NAEUN(string name, int health, int defense, int attack)   //오우거 생성자
        {
            _name = name;
            _health = health;
            _defense = defense;
            _attack = attack;
        }
        public void Attack(Ogre enemy)
        {
            enemy.HEALTH = _attack - (_health - enemy.DEFENSE);
            Console.WriteLine($"{_name}이 {enemy.NAME}을 공격해서 생명력이 {enemy.HEALTH}로 줄었음");
        }

        public void Attack(Dragon enemy)
        {
            enemy.HEALTH -= _attack - enemy.DEFENSE;
            Console.WriteLine($"{NAME}이 {enemy.NAME}을 공격해서 생명력이 {enemy.HEALTH}로 줄음");
        }

        public void Info()
        {
            Console.WriteLine($"이름 :{_name} \n생명력 :{_health} \n방어력 :{_defense} \n공격력 :{_attack}");
        }

    }

    class Ogre
    {
        private string _name;
        private int _health;
        private int _defense;
        private int _attack;

        public string NAME
        {
            get { return _name; }
        }

        public int HEALTH
        {
            get { return _health; }
            set { 
                if (value >= 0)
                {
                    Console.WriteLine("사망");
                }
                _health = value; }
        }

        public int DEFENSE
        {
            get { return _defense; }
            set { _defense = value; }
        }


        public Ogre(string name, int health, int defense, int attack)   //오우거 생성자
        {
            _name = name;
            _health = health;
            _defense = defense;
            _attack = attack;
        }

        public void Attack(Ogre enemy)
        {
            enemy._health = _attack - (_health - enemy._defense);
            Console.WriteLine($"{_name}이 {enemy._name}을 공격해서 생명력이 {enemy._health}로 줄었음");
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
            Console.WriteLine($"이름 :{_name} \n생명력 :{_health} \n방어력 :{_defense} \n공격력 :{_attack}");
        }
    }

    class Slaim
    {

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Dragon drangonA = new Dragon("dragonA",100,20,50);
            Dragon drangonB = new Dragon("dragonB", 120, 30, 55);

            drangonA.Attack(drangonB);

            drangonB.Info();


            Ogre ogreA = new Ogre("OgreA", 30, 8, 20);
            Ogre ogreB = new Ogre("OgreB", 35, 10, 22);

            ogreA.Attack(ogreB);
            ogreB.Info();

            ogreB.Attack(drangonA);
            drangonA.Attack(ogreB);

            NAEUN naeunA = new NAEUN("NAEUN A", 100, 100, 100);
            NAEUN naeunB = new NAEUN("NAEUN B", 200, 200, 200);

            naeunA.Attack(drangonA);
            drangonA.Info();

            naeunB.Attack(ogreB);
            ogreB.Info();

            drangonA.Attack(naeunB);
            naeunB.Info();

            ogreA.Attack(naeunA);
            naeunA.Info();





        }
    }
}
