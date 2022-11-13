using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Weekend53
{
    class Monster
    {
        public void Attack()
        {
            Console.WriteLine("Monster Attack");
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                //null 집합연산자
                string str1 = "Monster";
                Console.WriteLine(str1 ?? "없음");    //널이 아니니까 str1 출력

                str1 = null;
                Console.WriteLine(str1 ?? "없음");    //널로 만들었기 때문에 없음 출력

                //null 조건부 연산자
                Monster mons = new Monster();

                mons?.Attack();

                mons = null;

                mons?.Attack();

                if (mons != null)
                {
                    mons.Attack();
                }

            }
        }
    }
}
