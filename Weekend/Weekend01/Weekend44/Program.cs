using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace Weekend44
{

    /*
     배열 : 데이터 저장공간이 인접해서 만들어지기 때문에 배열식을 사용할 수 있다.
    int [] array = new int[10] 
    배열에 메모리가 할당되고 주소값이 할당되게 된다. => c,c++
    객체 안에 동적으로 할당되고 인접해서 공간이 만들어져서 배열식을 사용 (임의접근) 
    번호를 부여한건 아니지만 선두번지 주소로부터 0칸 떨어진 array[0]이렇게 쓸 수 있음
    인덱스 번호만 안다면 그 공간에 바로 접근할 수 있음.
    단점은 한번 공간을 할당받으면 사이즈를 늘릴 수 없음. 데이터 공간이 fixed 되었을 때 사용 가능하다
    삽입하거나 삭제할 떄, 구조 자체가 용이하지 않다.

    데이터의 사이즈가 가변적일 떄에는 배열이 적합하지 않다 그래서 나온게 LinkedList

    리스트 : 데이터 조각을 조각내서 서로 연결하는 것. 데이터 저장을 하는 단위를 노드라고 한다.
    앞쪽 노드가 뒷쪽 노드의 주소값을 물고 있어서 연결할 수 있는 것임
    물리적으로는 저장공간이 떨어져있는데, 논리적으로 연결하는 것.

    요즘에는 리스트를 많이 쓰는 추세지만 배열이 가능하면 배열을 쓰는 것이 가장 좋다

    뒷쪽의 노드 주소값을 저장하게 되는 리스트 : single linked list
    앞쪽과 뒷쪽의 노드 주소값을 저장하게 되는 리스트도 있다 double linked list => c#

    자료구조를 쓸 때 : 삽입과 삭제가 빈번한지, 데이터의 메모리가 fixed 되어있는지

    스택 : 항아리구조 (데이터가 들어가는 입구랑 나오는 입구가 같다)
           후입선출의 구조를 가지고 있다 LIFO (UI CONTROL/ UNDO : 이전에 했던 작업을 역순으로 돌릴 때 사용)
           MAIN UI가 있을거고 초기화면이 있는데 INIT UI / GAME UI / OPTION..
           INIT UI로 들어가면 이전에 있던 메인UI를 저장, INIT -> OPTION 

    큐 : 대롱구조 ( 데이터가 들어가는 입구랑 나오는 입구가 다르다)
         선입선출의 구조를 가지고 있다 (FIFO (어떤 작업을 대기시켜놓을 떄. 처리는 해야하는데 바로 처리는 안돼
                                                그래서 임시적으로 대기시켜놓을 떄 쓴다 , 은행에서 번호표를 뽑을 떄 쓴다)
         스타크래프트에서 건물지을 떄 5분 2분 1분이 걸리면 5분동안 큐에서 잡고 있다가 건물을 생성해준다
         작업을 대기시켜놨다가 처리할 때 쓴다.

    COLLEXTION : 유용하게 쓰는 데이터를 저장하는 방식
    using System.Collections;

   
     
     */
    class A
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            //Array
            Console.WriteLine("\n배열\n");
            ArrayList array = new ArrayList();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add("monster");
            array.Add(1.2);


            for(int i = 0; i < array.Count; i++)
            {
                Console.WriteLine($"array[{i}] = " + array[i]);
            }

            foreach(var obj in array)
            {
                Console.WriteLine(obj);
            }

            //Stack
            Console.WriteLine("\n스택\n");
            Stack stack = new Stack();
            //집어넣는걸 push 끄집어내면 pop 들어다보면 top
            for(int i =0; i<10; i++)
            {
                stack.Push(i);  //스택에 값을 집어넣는다
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
                Console.WriteLine("{0}",stack.Pop());
            }

            //Queue 
            Console.WriteLine("\n큐\n");
            Queue queue = new Queue();
            //데이터를 밀어넣을 때 enqueue, 끄집어낼 때 dequeue : 어떤 값을 당장 처리할 수 없을 때 사용 (임시적으로 대기시켜놓을 때)

            for(int i =10; i >= 0; i--)
            {
                queue.Enqueue(i);   //큐에 값을 넣는다
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue()); //큐에서 값을 꺼낸다
            }

            Console.WriteLine("\n해쉬테이블\n");
            //해쉬테이블
            //배열은 임의접근이라는 장점이 있다
            //리스트같은 경우는 4라는 수가 있을 때 4냐고 계속 물어봐야 하는데, 배열은 인덱스 번호만 안다면 바로 접근할 수 있음
            //리스트는 항상 앞쪽부터 뒷쪽까지 순차적으로 접근을 해야 하는데 배열은 바로 접근이 가능하다
            //이 장점을 살려보자고 만든 자료구조가 해쉬테이블이다
            //얘는 데이터를 키와 밸류 형태로 저장을 한다 키값은 인덱스를 구할 떄 사용한다. 
            //그래서 이 키를 가지고 인덱스 값을 가지는데 그 때 사용하는 것을 해쉬라고 한다.

            Hashtable hashtable = new Hashtable();
            hashtable.Add("Apple", 123);
            hashtable["banana"]=123;
            hashtable[100] = "monster";
            hashtable[1.2] = "monster1.2";
            hashtable[1000] = 10000;

            //키값을 가지고 배열의 인덱스값을 만들어서 사용하는 것

            Console.WriteLine("Apple : {0}", hashtable["Apple"]);
            Console.WriteLine("hashtable[1000] : {0}", hashtable[1000]);

            //위의 컬렉션들은 object 데이터 타입으로 저장을 한다
            //최상위는 object 고 나머지는 object를 상속받아서 만들어진다 ( int, float, string..)
            //그러면 부모의 데이터 타입으로 자식을 받을 수 있기 떄문에 

            int i1 = 10;
            float j1 = 1.2f;
            object obj1 = i1; //박싱 : 값타입을 참조타입으로 변경되는 것, 스택에 있던 값을 동적메모리에 할당
            int a = (int)obj1;   //언박싱 : 참조타입을 값타입으로 변경, 동적메모리에 할당된 값을 스택에 만듬
            obj1 = j1;
            obj1 = new A();  //클래스도 받는다.
                            //

            //i라는 변수는 값타입이고 그건 스택에 만들어지는데, object는 참조타입이기 때문이기 때문에 용량이 늘어나고 비효율적이다.
            ////따라서 ArrayList 는 오브젝트 타입으로 받기 떄문에 이렇게 쓰지 않는다.
            ///참조타입의 값을 값타입으로 바꾸는걸 언박싱이라고 한다
            ///스택 -> 힙 박싱
            ///힙 -> 스택 언박싱
            ///스택 값 int 를 오브젝트 타입으로 변경하면 그 값을 동적메모리에 저장하고 그 주소값을 obj가 참조하게 되는 것
            ///그 당시에는 이 방법밖에 없었기 때문에 채택을 했음. 그 다음에 obj 값을 다시 int형 값으로 바꿔서 썼음
            ///코드 : 함수 , 데이터 : 정적변수 전역변수 , 
            ///힙(참조타입) : 그때그때 만들어지는 동적 메모리 공간 , 
            ///스택(값타입) : 중괄호블럭에 들어갔다가 만들어졌다가 중괄호 블럭 나가면 사라지는 자동변수
            



            

        }
        
    }
}
