using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Weekend35
{
    class Heart
    {
        public void CheckHeart()
        {
            Console.WriteLine("심장이 정상작동중입니다");
        }
    }

    class SmartPhone
    {
        private string _brandName;
        public SmartPhone(string brand)
        {
            _brandName = brand;
        }

        public void Display()
        {
            Console.WriteLine($"{_brandName}폰이 정상작동중입니다");
        }
    }
    class Human
    {
        private Heart _heart = new Heart(); //일반적으로 포함관계임 . 각각 따로 없어지겠지만.. 이 경우는 휴먼 만들 때 같이 만들고
                                            //같이 없어진다는 개념으로 보는게 나을것이다
                                            //c#에서는 이렇게밖에 할 수 없음 객체를 만들 때
                                            //일반 값타입으로 만들 수 없고 뉴로 할당해야함 항상 힙에만 저장됨
                                            //c#에서 참조한다고 하는걸 c++에서는 포인터로 이해하면 된다

        private SmartPhone _smartPhone;  //이런 경우를 aggregation
                                        //c++에서는 이런식으로 만들 수 있음
        public Human(SmartPhone smartPhone)
        {
            
            _smartPhone = smartPhone;
        }

        public void CheckHeart()
        {
            _heart.CheckHeart();
        }

        public void UsePhone()
        {
            _smartPhone.Display();
        }

        public void ChangePhone(SmartPhone phone)
        {
            _smartPhone = phone;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            SmartPhone samsumgPhone = new SmartPhone ("Samsung");
            SmartPhone Iphone = new SmartPhone("Apple");
            Human human = new Human(samsumgPhone);

            human.CheckHeart(); //심장이 정상작동중입니다
            human.ChangePhone(samsumgPhone);    //삼성폰이 정상작동중입니다
            human.UsePhone();
            human.ChangePhone(Iphone);  //애플폰이 정상작동중입니다


            Human human2 = new Human(Iphone);

            human2.UsePhone();


        }
    }
}
