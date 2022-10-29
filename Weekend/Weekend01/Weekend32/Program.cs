using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Weekend32
{
    /*
     애매한 종류가 들어오면 부모에서 자식을 분리해낸다(돌고래 같은 경우)
     
     */
        //enum AnimalType
        //{
        //    Pig,
        //    Cow,
        //    Chicken,
        //    Dolphin
        //}

        class Animal
        {

            /*private AnimalType _type;*/   //타입변수를 없앰

            //private string _name;
            //private float _age;
            //private float _weight;
            //private float _healthrate;

            protected string _name; //자식이 받을 수 있도록 protected로 바꾸어준다
            protected float _age;
            protected float _weight;
            protected float _healthrate;

            public Animal(/*AnimalType type, */string name, float age, float weight, float healthrate)  //기본적인 부분만 받음
            {
                //_type = type;
                _name = name;
                _age = age;
                _weight = weight;
                _healthrate = healthrate;
                //_isFly = isFly;
            }

            public virtual void Speak()
            {
                Console.WriteLine($"{_name}이 말한다");     //speak라는건 공통되지만 안의 로직은 다르기 때문에 분리해준다
            }

            public void Run()
            {
                Console.WriteLine($"{_name}이 뛴다");     //speak라는건 공통되지만 안의 로직은 다르기 때문에 분리해준다
            }

            //switch (_type)
            //    {
            //        case AnimalType.Pig:
            //            Console.WriteLine($"{_name}이 꿀꿀합니다");
            //            break;

            //        case AnimalType.Cow:
            //            Console.WriteLine($"{_name}이 음메합니다");
            //            break;

            //        case AnimalType.Chicken:
            //            Console.WriteLine($"{_name}이 꼬끼오합니다");
            //            break;
            //    }
            //}

            //private void Fly()  //나는 것은 치킨만의 속성이니까 치킨한테 준다
            //{
            //    Console.WriteLine($"{_name}이 납니다");
            //}

            //public void Run()
            //{
            //    if (_isFly)
            //    {
            //        Fly();
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{_name}이 뜁니다");
            //    }
            //}

            public void CheckHealthRate()
            {
                if (_healthrate <= 100 && _healthrate > 80)
                {
                    Console.WriteLine($"{_name}의 건강이 아주 좋습니다");
                }
                else if (_healthrate <= 80 && _healthrate > 60)
                {
                    Console.WriteLine($"{_name}의 건강이 좋습니다");
                }
                else if (_healthrate <= 60 && _healthrate > 40)
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
                //if (_isFly)
                //{
                //    Console.WriteLine($"{_name}은 날 수 있습니다");
                //}
                //else
                //{
                //    Console.WriteLine($"{_name}은 날 수 없습니다");
                //}

            }

        }

        class Pig : Animal
        {

            public Pig(string name, float age, float weight, float healthrate) : base(name, age, weight, healthrate)
            {

            }

            public new void Speak()
            {
                Console.WriteLine($"{_name}이 꿀꿀합니다");
            }

        }

        class Cow : Animal
        {

            public Cow(string name, float age, float weight, float healthrate) : base(name, age, weight, healthrate)
            {

            }

            public void Speak()
            {
                Console.WriteLine($"{_name}이 음메합니다");
            }
        }

        class Chicken : Animal
        {
            private bool _isFLY;
                
            public Chicken(string name, float age, float weight, float healthrate, bool isFly) : base(name, age, weight, healthrate)
            {
                _isFLY = isFly;
            }

            /*public new void Speak()   */  //재정의하는거라서 new를 붙여준다
            public override void Speak()
            {
                Console.WriteLine($"{_name}이 꼬꼬합니다");
            }

            private void Fly()  //나는 것은 치킨만의 속성이니까 치킨한테 준다
            {
                Console.WriteLine($"{_name}이 납니다");
            }

            public void Run()
            {
                if (_isFLY)
                {
                    Fly();

                }
                else
                {
                    Console.WriteLine($"{_name}이 뜁니다");
                }
            }

            public new void Info()
            {
                base.Info();
                if (_isFLY)
                {
                    Console.WriteLine("난다");
                }
            }

         }

        class Dolphin : Animal
        {
            public Dolphin(string name, float age, float weight, float healthrate) : base(name, age, weight, healthrate)
            {

            }

            private void Swim()  //헤엄치는 것은 돌고래만의 속성이니까 치킨한테 준다
            {
                Console.WriteLine($"{_name}이 헤엄친다");
            }
            public new void Speak()     //재정의하는거라서 new를 붙여준다
            {
                Console.WriteLine($"{_name}이 끽끽합니다");
            }

            public new void Run()
            {
                Swim();
            }

        }   
    internal class Program
        {
            static void Main(string[] args)
            {
                Pig pig = new Pig("돼지", 2.8f, 180f, 60.0f);
                Cow cow = new Cow("소", 1.9f, 200.0f, 83.0f);
                Chicken notFlyChicken = new Chicken("닭", 0.8f, 3.0f, 20.0f, false);
                Chicken FlyChicken = new Chicken("닭", 0.8f, 4.0f, 90.0f, true);
                Dolphin dolphin = new Dolphin("돌고래", 2.9f, 230.0f, 20f);

                Console.WriteLine("Speak");

                pig.Speak();
                cow.Speak();
                notFlyChicken.Speak();
                FlyChicken.Speak();
                dolphin.Speak();

                Console.WriteLine("HealthRate");

                pig.CheckHealthRate();
                cow.CheckHealthRate();
                notFlyChicken.CheckHealthRate();
                FlyChicken.CheckHealthRate();
                dolphin.CheckHealthRate();

                Console.WriteLine("Information");

                pig.Info();
                FlyChicken.Info();
                notFlyChicken.Info();
                FlyChicken.Info();
                dolphin.Info();


            /*우리는 부모 타입으로 자식을 받을 수 있으니까..*/

                Animal[] animals = new Animal[5];   //부모타입의 배열을 만든 다음에 자식들을 받을 수 있음

                animals[0] = pig;
                animals[1] = cow;
                animals[2] = notFlyChicken;
                animals[3] = FlyChicken;
                animals[4] = dolphin;

                for(int i = 0; i < animals.Length; i++)
                {
                    animals[i].Speak();
                }    
                //상속을 시키니까 부모타입에다가 자식을 밀어넣고 일괄적으로 처리할 수 있음

                /*
                 어떤 객체가 다른 객체를 멤버로 가지고 있다는 걸 포함이라고 한다
                 포함도 두 가지 경우가 있음. 포함된 객체가 생명주기를 같이 한다는 것을 포함이라고 하고 (강한결합 : 심장같은거임/ 뗄 수 없음)
                 생명주기를 같이 하지 않는 경우를 참조라고 한다 ( 느슨한결합 : 나와 나의 스마트폰 같은 느낌. 생명주기를 같이 안하고
                 필요에 의해서 서로 연결된 관계)
                 
                기본적으로 c#에서는 객체가 따로따로 만들어짐 . 클래스형 데이터 타입은 무조건 동적메모리 힙에 만들어져서 
                 */
            }
        }
    }

