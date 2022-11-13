using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend54
{/*
  
  인터페이스는 행동만 설정할 수 있다
  */
    // interface (행동규약)

    interface iMove
    {
        public void Move();
    }

    class Human : iMove
    {
        public void Walk()
        {
            Console.WriteLine("Walk");
        }

        public void Run()
        {
            Console.WriteLine("Run");
        }

        public void Move()
        {
            Run();
        }

    }
    class Car : iMove
    {
        public void Drive()
        {
            Console.WriteLine("Drive");
        }

        public void Accel()
        {
            Console.WriteLine("Accel");
        }

        public void Move()
        {
            Drive();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            iMove[] moves = new iMove[2];

            moves[0] = new Human();
            moves[1] = new Car();

            foreach (var obj in moves)
            {
                obj.Move();
            }

        }
    }
}
