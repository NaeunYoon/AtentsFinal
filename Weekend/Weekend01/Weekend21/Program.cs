using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend21
{
    public class Car    
    {
        private float _speed;
        private int _wheelCount;
        private string _type;

        public Car() : this(100f, 4, "택시") //기본생성자에 값넣기
        {
            //기본으로 호출했지만 그 안에서 인자 3개를 받는 생성자 호출
        }

        //매개변수가 있는 생성자를 만들면 기본생성자를 컴파일러 자동으로 만들어 주지 않습니다

        public Car(float speed, int wheelCount, string type)    //매개변수가 있는 생성자
        {
            _speed = speed;
            _wheelCount = wheelCount;
            _type = type;
        }

        public Car(float speed)
        {
            _speed = speed;
            _wheelCount = 4;
            _type = "없음";
        }

        public void Break()
        {

            Console.WriteLine("없음");
        }

        public void info()
        {
            Console.WriteLine($"속도 : [{_speed}, 바퀴 {_wheelCount}, 차종{_type}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(200f,4,"스포츠카");        //생성자를 호출해서만 객체를 만들어야 함 (인자를 3개 받는 생성자)

            car.info();
            car.Break();

            Car car2 = new Car(100f);
            car2.info();

            Car car3 = new Car();
            car3.info();

            
        }
    }
}
