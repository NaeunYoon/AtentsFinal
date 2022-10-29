using System;

namespace Weekend29
{
    // 동물농장 시뮬레이션
    // 동물 육성해서 팔아서 농장을 발전시키는 게임
    // 돼지, 소, 닭

    class Stock
    {
        //private string _name;
        //private float _age;
        //private float _weight;
        //private float _healthrate;


        protected string _name;
        protected float _age;
        protected float _weight;
        protected float _healthrate;
        public string Name
        {
            set => _name = value;
            get => _name;
        }


        public Stock(string name, float age, float weight, float healthrate)
        {
            _name = name;
            _age = age;
            _weight = weight;
            _healthrate = healthrate;
        }

        public void Speak()
        {
            Console.WriteLine($"{_name}이 말한다.");
        }

        public void Eat()
        {
            Console.WriteLine($"{_name}이 먹는다.");
        }

        public void Run()
        {
            Console.WriteLine($"{_name}이 걷는다.");
        }


        public void info()
        {
            Console.WriteLine($"이름:{_name}\n" +
                $"나이:{_age}\n" +
                $"몸무게:{_weight}\n" +
                $"건강지수:{_healthrate}");
        }

    }


    class Pig : Stock
    {
        public Pig(string name, float age, float weight, float healthrate)
            : base(name, age, weight, healthrate)
        {

        }
        public void Speak()
        {
            Console.WriteLine($"{_name}이 꿀꿀한다.");
        }
    }


    class Cow : Stock
    {
        public Cow(string name, float age, float weight, float healthrate)
            : base(name, age, weight, healthrate)
        {
        }
        public void Speak()
        {
            Console.WriteLine($"{_name}이 음메한다.");
        }

    }
    class Sheep : Stock
    {
        public Sheep(string name, float age, float weight, float healthrate): base(name, age, weight, healthrate)
        {
        }
        public void Speak()
        {
            Console.WriteLine($"{_name}이 메에한다.");
        }
    }


    class Chicken : Stock
    {
        private bool _isFly;

        public Chicken(string name, float age, float weight, float healthrate, bool isFly)
            : base(name, age, weight, healthrate)
        {
            _isFly = isFly;
        }
        public void Speak()
        {
            Console.WriteLine($"{_name}이 꼬꼬한다.");
        }
        private void Fly()
        {
            Console.WriteLine($"{Name}이 납니다.");
        }

        public new void Run()
        {
            if (_isFly)
            {
                Fly();
            }
            else
            {
                Console.WriteLine($"{Name}이 걷는다.");
            }

        }


        public new void info()
        {
            base.info();

            if (_isFly)
            {
                Console.WriteLine("나는닭");
            }
            else
            {
                Console.WriteLine("못나는 닭");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pig pig = new Pig("돼지", 2.3f, 130.0f, 88.0f);
            Cow cow = new Cow("소", 1.8f, 200.0f, 90.0f);
            Chicken flyChicken = new Chicken("나는 닭", 1.2f, 3.0f, 90.0f, true);
            Chicken NotFlyChicken = new Chicken("못 나는 닭", 1.8f, 4.0f, 90.0f, false);
            Sheep sheep = new Sheep("양", 1f, 5f, 4f);

            pig.Speak();
            cow.Speak();
            flyChicken.Speak();
            NotFlyChicken.Speak();
            sheep.Speak();
        }
    }
}
