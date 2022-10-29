using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend36
{/*
  객체간의 관계를 맺는 방법중에 상속과 포함을 배웠어요

    상속을 하게 되면 구조가 딱딱해져요
    그래서 요즘엔 포함을 하는 추세애요

    로켓이랑 캐논이 구조가 비슷해서 상속하려 했는데 데이터타입이 다르네..?
    그럼 암을 상속시키기로 했엉
    부모의 타입으로 받을 수 있으니까 바꿔주자
  
  */

    class Arm
    {

    }

    class CannonArm : Arm
    {
        private string _name;

        public CannonArm()  
        {
            _name = "CanonArm";
        }

        public void Info()
        {
            Console.WriteLine($"{_name}");
        }
    }
    class RoketArm : Arm
    {
        private string _name;

        public RoketArm()
        {
            _name = "RoketArm";

        }

        public void Info()
        {
            Console.WriteLine($"{_name}");
        }

    }

    class RoketArmRobot
    {

        RoketArm _leftArm = new RoketArm();
        RoketArm _rightAARM = new RoketArm();

        public RoketArmRobot()    //생성자
        {

        }

        public void Info()
        {
            Console.WriteLine("왼쪽 팔");
            _leftArm.Info();
            Console.WriteLine();
            Console.WriteLine("오른쪽 팔");
            _rightAARM.Info();
            Console.WriteLine("\n");
        }
    }



    class CannonArmRobot
    {
        CannonArm _leftArm = new CannonArm();
        CannonArm _rightAARM = new CannonArm();

        public CannonArmRobot()    //생성자
        {

        }

        public void Info()
        {
            Console.WriteLine("왼쪽 팔");
            _leftArm.Info();
            Console.WriteLine();
            Console.WriteLine("오른쪽 팔");
            _rightAARM.Info();
            Console.WriteLine("\n");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CannonArmRobot cannonArmRobot = new CannonArmRobot();
            cannonArmRobot.Info();

            RoketArmRobot roketArmRobot = new RoketArmRobot();
            roketArmRobot.Info();
        }
    }
}
