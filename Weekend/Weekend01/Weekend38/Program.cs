using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend38
{
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

    #region 로봇클래스
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
    #endregion

    #region 로봇들
    //class CannonArmRobot : Robot
    //{
    //    public CannonArmRobot(CannonArm leftArm, CannonArm rightArm) : base(leftArm, rightArm)
    //    {

    //    }
    //}

    //class RocketArmRobot : Robot
    //{
    //    public RocketArmRobot(RocketArm leftArm, RocketArm rightArm) : base(leftArm, rightArm)
    //    {

    //    }
    //}

    //class LazerArmRobot : Robot
    //{
    //    public LazerArmRobot(LazerArm leftArm, LazerArm rightArm) : base(leftArm, rightArm)
    //    {

    //    }
    //}
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            CannonArm cannonArm = new CannonArm();
            RocketArm rocketArm = new RocketArm();
            LazerArm lazerArm = new LazerArm();

            Robot cannonArmRobot = new Robot(new CannonArm(), new CannonArm());
            cannonArmRobot.Info();

            Robot rocketArmRobot = new Robot(new RocketArm(), new RocketArm());
            rocketArmRobot.Info();

            Robot lazerArmRobot = new Robot(new LazerArm(), new LazerArm());
            lazerArmRobot.Info();

            Robot lLazerrCannonArmRobot = new Robot(lazerArm, cannonArm);
            lLazerrCannonArmRobot.Info();

            

        }
    }
}

