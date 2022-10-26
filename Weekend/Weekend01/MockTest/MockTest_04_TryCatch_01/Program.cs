using System.ComponentModel;

namespace MockTest_04_TryCatch_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
			/*
			보통은 에러가 발생하면 프로그램이 종료된다
			*/	
			try
			{
				//에러가 발생하면 바로 catch로 넘어가게 하는 코드
				Console.WriteLine("try");
				/*return;*/    //리턴이 되었는데도 finally는 실행됨 ;;
							   //Console.WriteLine("after return");

				int [] arr = new int[10];
				int b = arr[0] / 0; //Attempted to divide by zero.
				int c = arr[-1]; //Index was outside the bounds of the array.

                //throw new Exception();
            }
			catch (IndexOutOfRangeException e)
			{
				//서버에서 주로 사용함 : 클라이언트는 재접이 가능하지만 서버는 그렇지 않기 때문에 (클라이언트도 사용해도 되긴 함)
				//주로 기록을 따로 하고 있다가 점검날에 코드를 고침
				//에러 발생 시 도달하는 곳
				Console.WriteLine("catch1");
				Console.WriteLine(e.Message);	//보통은 어떤 종류의 예외인지 메세지 보려고 출력함
				//throw;


			}
			catch (DivideByZeroException e)
			{
                Console.WriteLine("catch1");
                Console.WriteLine(e.Message);
            }
			finally
			{
				//에러가 발생하던 발생 안하던 동작함 (무조건 실행)
				Console.WriteLine("finally");
			}
			Console.WriteLine("after try");
        }
    }
}