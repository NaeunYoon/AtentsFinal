using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Weekend31
{
    enum AnimalType
    {
        Pig,
        Cow,
        Chicken
    }

    class Animal
    {

        private AnimalType _type;

        private string _name;
        private float _age;
        private float _weight;
        private float _healthrate;
        private bool _isFly;


        public Animal(AnimalType type, string name, float age, float weight, float healthrate, bool isFly)
        {
            _type = type;
            _name = name;
            _age = age;
            _weight = weight;
            _healthrate = healthrate;
            _isFly = isFly;
        }

        public void Speak()
        {
            switch (_type)
            {
                case AnimalType.Pig:
                    Console.WriteLine($"{_name}이 꿀꿀합니다");
                    break;

                case AnimalType.Cow:
                    Console.WriteLine($"{_name}이 음메합니다");
                    break;

                case AnimalType.Chicken:
                    Console.WriteLine($"{_name}이 꼬끼오합니다");
                    break;
            }
        }

        private void Fly()
        {
            Console.WriteLine($"{_name}이 납니다");
        }

        public void Run()
        {
            if (_isFly)
            {
                Fly();
            }
            else
            {
                Console.WriteLine($"{_name}이 뜁니다");
            }
        }

        public void CheckHealthRate()
        {
            if(_healthrate <=100 && _healthrate > 80)
            {
                Console.WriteLine($"{_name}의 건강이 아주 좋습니다");
            }else if(_healthrate <=80 && _healthrate > 60)
            {
                Console.WriteLine($"{_name}의 건강이 좋습니다");
            }else if(_healthrate <=60 && _healthrate > 40)
            {
                Console.WriteLine($"{_name}의 건강이 보통입니다");
            }
            else
            {
                Console.WriteLine($"{_name}은 정밀검사가 필요합니다");
            }
        }

        public void Info()
        {
            Console.WriteLine($"이름 : {_name}, 나이 : {_age}, 체중 : {_weight}");
            CheckHealthRate();
            if (_isFly)
            {
                Console.WriteLine($"{_name}은 날 수 있습니다");
            }
            else
            {
                Console.WriteLine($"{_name}은 날 수 없습니다");
            }
            
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Animal pig = new Animal(AnimalType.Pig, "돼지", 2.8f,180f, 60.0f, false);
            Animal cow = new Animal(AnimalType.Cow, "소", 1.9f, 200.0f,83.0f, false);
            Animal notFlyChicken = new Animal(AnimalType.Chicken, "닭", 0.8f, 3.0f, 20.0f, false);
            Animal FlyChicken = new Animal(AnimalType.Chicken, "닭", 0.8f, 4.0f, 90.0f, true);

            Console.WriteLine("Speak");

            pig.Speak();
            cow.Speak();
            notFlyChicken.Speak();
            FlyChicken.Speak();

            Console.WriteLine("HealthRate");

            pig.CheckHealthRate();
            cow.CheckHealthRate();
            notFlyChicken.CheckHealthRate();
            FlyChicken.CheckHealthRate();

            Console.WriteLine("Information");

            pig.Info();
            FlyChicken.Info();
            notFlyChicken.Info();
            FlyChicken.Info();

        }
    }
}
