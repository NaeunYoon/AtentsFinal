namespace MockTest_03_ThreadExample_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             그니까 결론적으로 이렇게 하면 세 스레드가 지 멋대로 한꺼번에 잘 돌아감
             */
            Thread t1 = new Thread(Update_1);
            t1.Start();
            Thread t2 = new Thread(Update_2);
            t2.Start();
            Thread t3 = new Thread(Update_3);
            t3.Start();
        }
        static void Update_1()
        {
            int cnt = 0;
            for (int i = 0; i < 50; i++)
            {
                cnt++;
                Console.WriteLine("Update_1 :" + cnt);
            }
        }

        static void Update_2()
        {
            int cnt = 0;
            for (int i = 0; i < 50; i++)
            {
                cnt++;
                Console.WriteLine("Update_2 :" + cnt);
            }
        }

        static void Update_3()
        {
            int cnt = 0;
            for (int i = 0; i < 50; i++)
            {
                cnt++;
                Console.WriteLine("Update_3 :" + cnt);
            }
        }
    }
}