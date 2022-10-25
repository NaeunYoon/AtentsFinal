using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;   //
using System.Text;
using System.Threading.Tasks;   //
using System.Threading; //
using System.Net;   //

namespace Atents_GameNetWork_03_Thread
{
    internal class Program
    {
        static Thread t1;   //1. thread 와 관련된 데이터와 기능을 모아놓은 클래스가 존재한다

        static void Main(string[] args)
        {
            //3.thread start라는 매개변수가 필요함
            ThreadStart threadStart = new ThreadStart(NewClient);   //스타트가 시작되면 뉴 클라이언트 함수가 실행됨
                                                                    //스레드 실행항 때 스레드 구동함수를 만들어서 전달

            
            //threadstart 자료형 사용
            t1 = new Thread(threadStart);  //2. 생성자 호출  //스레드 생성


            

            t1.Start(); //스레드 구동 함수
            Console.WriteLine("Start");

            int count = 0;
            while (count<300)   //메인함수 그대로 조인
            {
                count++;
                Console.WriteLine("메인함수 "+count);
            }

            t1.Join();  //두개의 스레드가 구동되고 있는데 조인이 호출되면 프로세스 종료될 때 스레드도 종료가 되어야 하기 때문에
                        //조인을 시킴으로서 스레드를 종료 조인은 슬립상황에서 조인이 되는 것
                        //슬립이 되는 동안 메인함수가 구동되는거고 종료가 될 때 종료 시점에 조인을 시켜줘야 문제가 없음
                        //조인 후 인터럽트로 안정적으로 종료

            Console.WriteLine("Join");  //조인하기 위해서 슬립이 실행되어야 함 (슬립은 멈추는 것)
                                        //슬립 상태일 떄 조인이 될 수 있는것
                                        //슬립 조인 인터럽트
                                        //메인과 t1을 합치는 것

            t1.Interrupt(); //t1스레드 종료
            Console.WriteLine("Interrupt");
        }
        static void NewClient() //함수가 static인 경우는 변수도 static이여야만 함
        {
            int threadCount = 0;
            while (threadCount<300)
            {
                threadCount++;
                Console.WriteLine("Thread Test "+threadCount);  //메인함수 실행 도중에 thread 함수가 실행됨
                                                                //메인함수 끝나면 스레드 함수가 모두 실행됨
                                                                //스레드 함수가 끝나면 조인과 인터럽트 함수 호출
                Thread.Sleep(10);   //중간중간 호출되는 이유가 잠깐 
                                    //슬립되는 동안 메인스레드가 구동된다 
                                    //스레드에서는 반드시 슬립을 구현해줘야함
            }
        }
    }
}
