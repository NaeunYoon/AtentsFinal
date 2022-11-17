using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_42
{
    /*
     오버라이드는 일반적으로 virtual 메서드를 정의한 부모클래스에서 기본적인 기능을 구현,
     자식클래스에서는 override 예약어를 통해 기능을 재정의한다
     부모와 자식 모두 new를 이용해 인스턴스를 생성하는 것이 가능하다

     추상클래스 : 부모의 인스턴스를 생성하지 못하게 하면서 특정 메서드에 대해 자식들이 반드시 재정의하도록 강제
                  abstract 예약어가 지정되고 구현 코드가 없는 메서드이다
                  추상 메서드는 일반 클래스에 존재할 수 없으며, 반드시 추상 클래스 안에서만 선언할 수 있다
                  추상 클래스 안에 일반 메서드도 정의가 가능하다
                  추상 메서드에는 접근제한자로 private를 지정할 수 없다 ( 반드시 자식 클래스에서 재정의해야 하기 때문임)
                  new를 사용해 인스턴스로 만들 수 없으며 추상 메서드를 가질 수 있다
     
     */

    class Point
    {
        int x, y;

        public Point(int x, int y)  //생성자
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "\nx :" + x + ", y :" + y+ "\n";
        }
    }

    abstract class DrawingObject    //추상클래스
    {
        public abstract void Draw();    //추상메서드 : 코드 없는 가상 메서드

        public void Move() { Console.WriteLine("Move"); }   //일반 메서드 정의 가능

    }
    
    class Line : DrawingObject
    {
        Point p1, p2;   //어떻게 이렇게 했지................ ㅠㅠ
        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public override void Draw() //추상클래스의 추상 메서드를 반드시 정의해야 함
                                    //추상메서드는 가상 메서드에 속하기 때문에 자식 클래스에서 override 예약어를 사용해 재정의한다
                                    //가상 메서드 이므로 다형성의 특징이 적용된다
        {
            Console.WriteLine("Line" + p1.ToString() + "~" + p2.ToString());
            Console.WriteLine("Line" + p1 + "~" + p2);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DrawingObject line = new Line(new Point(10, 10), new Point(20, 20));    //다형성 (부모가 자식을 받음)
            line.Draw();    //다형성에 따라 Line.Draw() 가 호출된다

            line.Move();    //일반 메서드도 쓸 수 있음

        }
    }
}
