using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math2
{
    /* sealed class Math2*/ //sealed 라는 클래스를 쓰면 상속이 안된다
    class Math2
    {
        public int add(int a, int b)
        {
            return a + b;
        }

        public int mul(int a, int b)
        {
            return a * b;
        }

        public int sub(int a, int b)
        {
            return a - b;
        }
    }
}
