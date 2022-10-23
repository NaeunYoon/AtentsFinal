using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend27
{
    /*
      상속(inheritance) : 객체간의 관계를 맺는 방법 
      -상속과 포함으로 나누어진다
      -포함은 포함(Composition)과 참조(agregation)로 나누어진다
      -상속은 재사용성이 좋아진다 / 유지보수성이 좋아진다 / 다형성의 기반구조가 된다

    a는 부모 ( 기반 클래스 ) b는 자식 ( 유도 클래스)
    a의 기능도 가지고 있으면서 자기 자신의 기능도 가지고 있는 b

    1. 기존에 있던 클래스에서 공통된 부분을 상위클래스로 올린다 : 일반화
    2. 특수한 부분들을 내려서 자식클래스로 만들어서 상속 ( 역방향 ) : 특수화


     */

    //동물놀장 시뮬레이션 게임 : 동물을 육성해서 팔아서 농장을 발전시킨다
    //돼지 소 닭

    class Pig
    {
        private string _name;
        private float _age;
        private float _weight;
        private float _healthrate;


        public Pig(string name, float age, float weight, float healthrate)
        {
            _name = name;
            _age = age;
            _weight = weight;
            _healthrate = healthrate;
        }
        public void Speak()
        {
            Console.WriteLine($"{_name}이 꿀꿀");
        }
        public void Eat()
        {
            Console.WriteLine($"{_name}이 먹는다");
        }
        public void Run()
        {
            
            Console.WriteLine($"{_name}이 걷는다");
        }

        public void info()
        {
            Console.WriteLine($"이름{_name}, 나이{_age}, 몸무게{_weight}, 건강{_healthrate}");

            
        }
    }

    class Chicken
    {
        private string _name;
        private float _age;
        private float _weight;
        private float _healthrate;
        private bool _isFly;


        public Chicken(string name, float age, float weight, float healthrate, bool isFly)
        {
            _name = name;
            _age = age;
            _weight = weight;
            _healthrate = healthrate;
            _isFly = isFly;

        }
        private void Fly()      //바깥으로 노출 안함
        {
            Console.WriteLine($"{_name}이 난다");
        }

        public void Speak()
        {
            Console.WriteLine($"{_name}이 꼬끼오");
        }
        public void Eat()
        {
            Console.WriteLine($"{_name}이 먹는다");
        }
        public void Run()
        {
            if(_isFly == true)
            {
                Fly();
            }
            else
            {

                Console.WriteLine($"{_name}이 걷는다");
            }
        }

        public void info()
        {
            Console.WriteLine($"이름{_name}, 나이{_age}, 몸무게{_weight}, 건강{_healthrate}");

            if (_isFly)
            {
                Console.WriteLine("나는 닭");
            }
            else
            {
                Console.WriteLine("못나는 닭");
            }
        }
    }

    class Cow
    {
        private string _name;
        private float _age;
        private float _weight;
        private float _healthrate;

        public Cow(string name, float age, float weight, float healthrate)
        {
            _name = name;
            _age = age;
            _weight = weight;
            _healthrate = healthrate;
        }

        public void Speak()
        {
            Console.WriteLine($"{_name}이 음메");
        }
        public void Eat()
        {
            Console.WriteLine($"{_name}이 먹는다");
        }
        public void Run()
        {
            Console.WriteLine($"{_name}이 걷는다");
        }

        public void info()
        {
            Console.WriteLine($"이름{_name}, 나이{_age}, 몸무게{_weight}, 건강{_healthrate}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Pig pig = new Pig("돼지", 2.3f, 130f, 88f);
            Chicken flyChicken = new Chicken("나는 닭",3f,5f,6f,true);
            Chicken noFlyChicken = new Chicken("못나는 닭", 3f, 5f, 6f, false);
            Cow cow = new Cow("소", 100f, 50f, 50f);

            pig.Speak();
            pig.info();
            
            cow.Speak();
            cow.info();


            flyChicken.Speak();
            flyChicken.info();


            noFlyChicken.Speak();
            noFlyChicken.info();

        }
    }
}
