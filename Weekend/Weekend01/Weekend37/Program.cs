using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Weekend37
{/*
  암 타입으로 캐논암도 받고 로켓암도 받아서 상속을 시켰다
  팔만 틀린데 상속을 굳이 써야하는지 생각을 해봐야 한다.
    그냥 레프트는 레이저고 라이트는 캐논인데 이걸 위해 데이터타입을 또 만들어서 상속을 유지시켜야 할 필요성이 있을까.
  이런 경우에는 상속을 안시키고 다 지운 뒤 부모 로봇만 남겨둔다...그리고 팔을 바꾸는 함수를 추가해줌
    팔이 하나 틀리다는 이유로 상속을 쓰지 말고 그냥 포함관계를 유지하는게 더 낫겠다
    상속과 포함을 혼용해서 사용해도 되지만 로봇은 포함을 사용하는게 더 유용하다
  */
  
        #region Arm 부모클래스
        class Arm
        {
            private string _name;

            public Arm(string name)
            {
                _name = name;
            }

            public void Info()
            {
                Console.WriteLine(_name);
            }
        }
        #endregion

        #region 캐논암
        class CannonArm : Arm
        {
            public CannonArm() : base("CannonArm")
            {

            }
        }
        #endregion

        #region 로켓암
        class RocketArm : Arm
        {
            public RocketArm() : base("RocketArm")
            {

            }
        }
        #endregion
        #region 레이저암
        class LazerArm : Arm
        {
            public LazerArm() : base("LazerArm")
            {

            }
        }
        #endregion


        class Robot
        {
            private Arm _leftArm;
            private Arm _rightArm;

            public Robot(Arm leftArm, Arm rightArm)
            {
                _leftArm = leftArm;
                _rightArm = rightArm;   
            }

            public void Info()
            {
                Console.WriteLine("왼쪽팔");
                _leftArm.Info();
                Console.WriteLine("오른쪽팔");
                _rightArm.Info();

            }
        }


        class CannonArmRobot : Robot
        {
            public CannonArmRobot(CannonArm leftArm, CannonArm rightArm) : base(leftArm, rightArm) 
            {

            }
        }

        class RocketArmRobot : Robot
        {
            public RocketArmRobot(RocketArm leftArm, RocketArm rightArm) : base(leftArm, rightArm)
            {

            }
        }

        class LazerArmRobot : Robot
        {
            public LazerArmRobot(LazerArm leftArm, LazerArm rightArm) : base(leftArm, rightArm)
            {

            }
        }
  internal class Program
    {
        static void Main(string[] args)
        {

            CannonArm cannonArm = new CannonArm();
            RocketArm rocketArm = new RocketArm();
            LazerArm lazerArm = new LazerArm();

            CannonArmRobot cannonArmRobot = new CannonArmRobot(new CannonArm(),new CannonArm());
            cannonArmRobot.Info();

            RocketArmRobot rocketArmRobot = new RocketArmRobot(new RocketArm(),new RocketArm());
            rocketArmRobot.Info();

            LazerArmRobot lazerArmRobot = new LazerArmRobot(new LazerArm(),new LazerArm());
            lazerArmRobot.Info();
            
        }
    }
}
