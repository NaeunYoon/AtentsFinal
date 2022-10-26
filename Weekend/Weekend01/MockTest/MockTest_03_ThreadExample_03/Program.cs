namespace MockTest_03_ThreadExample_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             근데 나는 delegate를 사용한 thread를 만들어서 각 함수들을 굴비처럼 엮고싶어
             왜냐면 이걸 사용하면 함수를 변수처럼 더하고 뺄 수 있고든..
             이거는 비동기처럼 작용하진 않지만 내가 원하는 함수를 넣고 뺄 수 이써
             */

            ThreadStart thread1 = new ThreadStart(Update_1);
            thread1 += Update_2;
            thread1 += Update_3;
           /* thread1 -= Update_1;*/    //이렇게하면 update1번 안나옴

            Thread t1 = new Thread(thread1);
            t1.Start();

            int cnt = 0;        //메인함수꺼 스레드에 섞여서 나옴
            while (cnt < 100)
            {
                cnt++;
                Console.WriteLine("메인함수 "+cnt);
            }

            t1.Join();  // 조인이면 t1 스레드가 멈출때까지 아래 내용을실행시키기 않음 join은 sleep이랑 같이다님
            Console.WriteLine("Join");
            t1.Interrupt();
            Console.WriteLine("Interrupt");
            
        }
        static void Update_1()
        {
            int cnt = 0;
            for (int i = 0; i < 500; i++)
            {
                cnt++;
                Console.WriteLine("Update_1 :" + cnt);
            }
        }

        static void Update_2()
        {
            int cnt = 0;
            for (int i = 0; i < 500; i++)
            {
                cnt++;
                Console.WriteLine("Update_2 :" + cnt);
            }
        }

        static void Update_3()
        {
            int cnt = 0;
            for (int i = 0; i < 500; i++)
            {
                cnt++;
                Console.WriteLine("Update_3 :" + cnt);
            }
        }
    }
}