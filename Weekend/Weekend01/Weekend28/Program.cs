using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekend28
{
    class Stock
    {
        private string _name;
        private float _age;
        private float _weight;
        private float _healthrate;

        public string NAME
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

    public void Info()
    {
        Console.WriteLine($"이름{_name}, 나이{_age}, 몸무게{_weight}, 건강{_healthrate}");
    }
 }


    class pig : Stock
    {
        public pig(string name, float age, float weight, float healthrate) : base(name, age, weight, healthrate)
        {
        }
    }

    class chicken : Stock
    {
        private bool _isfly;

        public chicken(string name, float age, float weight, float healthrate, bool isfly) : base(name, age, weight, healthrate)
        {
            _isfly = isfly;

        }
        private void fly()      //바깥으로 노출 안함
        {
            Console.WriteLine($"{NAME}이 난다");
        }

        public new void run()   //자식이 재정의함
        {
            if (_isfly == true)
            {
                fly();
            }
            else
            {

                Console.WriteLine($"{NAME}이 걷는다");
            }
        }

        public new void Info()
        {
            if (_isfly)
            {
                Console.WriteLine("나는 닭");
            }
            else
            {
                Console.WriteLine("못나는 닭");
            }
        }
    }

    class cow : Stock
    {

        public cow(string name, float age, float weight, float healthrate) : base(name, age, weight, healthrate)
        {
        }

    }


    class program
    {
        static void main(string[] args)
        {
            pig pig = new pig("돼지", 2.3f, 130f, 88f);
            chicken flychicken = new chicken("나는 닭", 3f, 5f, 6f, true);
            chicken noflychicken = new chicken("못나는 닭", 3f, 5f, 6f, false);
            cow cow = new cow("소", 100f, 50f, 50f);

            pig.Speak();
            pig.Info();

            cow.Speak();
            cow.Info();

            flychicken.Speak();
            flychicken.Info();

            noflychicken.Speak();
            noflychicken.Info();

        }
    }
}

