namespace MockTest_04_TryCatch_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[4];
            try
            {
                Console.WriteLine("try");
                Console.WriteLine("문자열 입력");
                string message = Console.ReadLine();
                if (message.Contains("!"))
                {
                    throw new Exception("사용자 입력에 !가 있습니다");
                    arr[0] = 100;
                    arr[1] = 200;
                    arr[2] = 300;
                    arr[3] = 400;
                    arr[4] = 500;
                    Console.WriteLine(arr[4]);
                    Console.WriteLine("after exception");
                }
            
                
            }
            catch (Exception e)     //모든 예외에 대한 처리
            {
                Console.WriteLine("catch");
                Console.WriteLine(e.Message);
               /* return;*/ //catch문에서는 return을 일반적으로 작성 안함

            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }
}