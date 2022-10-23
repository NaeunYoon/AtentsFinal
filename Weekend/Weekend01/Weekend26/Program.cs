using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BOXING UNBOXING

            int i = 10; //=> 이건 스택에 만들어짐, 모든 데이터 타입은 오브젝트 타입이라는 데이터 타입의 자식으로 만들어져 있음
            object o = i;   //부모의 데이터 타입으로 자식의 데이터 타입을 받을 수 있음
                            //스택에 있던 애가 힙으로..옮겨감..(?
                            //박싱
                            //스택에 있던 값을 힙영역에서 참조하는걸 박싱

            i = (int)o;     //언받싱 
                            //힙영역에 있던걸 스택에 다시 넣는걸 언박싱
            
        }
    }
}
