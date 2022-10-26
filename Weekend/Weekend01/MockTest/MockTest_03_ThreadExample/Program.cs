namespace MockTest_03_ThreadExample
{
    internal class Program
    {
        /*
         내가 원하는게 업데이트 여러개를 만들어서 "한꺼번에 각자 따로 도는 것"을 만들고 싶음
         왜냐면 각각의 업데이트에 서로 다른 일을 시키고 싶거든

         유니티 서로 다른 컴포넌트들이 업데이트 문에서 따로 도는 것 = thread 따로따로 돌게 한다
         
         */


        static void Main(string[] args)
        {
            //이렇게 도는게 동기 방식인데(하나 끝나고 다음 함수 실행), 난 이렇게 하기 싫음 
            //왜냐면 끝날때까지 너무 오래걸려
            //Update_1();
            //Update_2();
            //Update_3();

            //그래서 Thread를 사용해서 비동기 형식으로 만들고 싶음

            //Thread 01 : Thread t1 = new Thread(비동기 하고싶은 함수이름);
            Thread t1 = new Thread(Update_1);   //오버로드 : 매개타입 및 변수가 다름
            t1.Start(); //start 함수 까먹으면 thread 시작 안하고 나은만 출력댐
            Console.WriteLine("나은1");    //이렇게 했더니 update_1번 출력하는 랜덤 시점에 나은이 호출댐 (처음 중간 끝 아무떄나 지 맘대로임)
                                         //어떤 스레드가 어떻게 할당받아서 작업하는지 나는 모르지만 정확한건 따로 돈다는 것임

            t1.Join();  //join은 start가 끝난 뒤에 실행된다 (join은 끝나는 시점을 알 수 있어서 사용함)
            Console.WriteLine("나은2");   //나은2는 join이 끝난 뒤에 출력된다

            t1.Interrupt(); //join이 끝나고 안전하게 종료하기 위해서 join과 interrupt는 같이 다님
                            //join 끝나면 끝남
                            //start 다음에 interrupt 있으면 start 함수 실행되는데 지 멋대로 멈춤
                            //중간에 에러났을 떄 멈추거나 실행되고 있는데 멈추는거 ㅇㅇ...또는 사용자가 멈추고싶으면 멈춤
            Console.WriteLine("나은3");

        }

        static void Update_1()
        {
            int cnt = 0;
            for(int i = 0; i < 50; i++)
            {
                cnt++;
                Console.WriteLine("Update_1 :"+cnt);
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