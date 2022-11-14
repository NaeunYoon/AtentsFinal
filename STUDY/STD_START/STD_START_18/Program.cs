using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Communication;    //
using Disk.FileSystem;  //

 /*
  네임스페이스 : 수많은 클래스들의 소속들 구분/분류하는 방법 ( 이름충돌 오류를 방지해준다)
                 네임스페이스로 구분된 블록 내에서는 동일한 이름 공간이 적용된다
                 네임스페이스가 다른 곳에서 클래스를 생성해야 한다면 네임스페이스.클래스 형식으로 지정한다
                 네임스페이스 안에 또 다른 네임스페이스를 중첩하는것도 가능하다
  */

namespace MilkyWay
{
    class Earth
    {

    }
}

namespace Andromeda
{
    class Eatth
    {

    }
}

namespace Communication
{
    class Http
    {

    }

    class Ftp
    {

    }
}

namespace Disk.FileSystem
{
    class File
    {

    }
}

namespace STD_START_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Communication.Http http = new Communication.Http();
            Disk.FileSystem.File file = new Disk.FileSystem.File();


            Http http2 = new Http();
            File file2 = new File();
        }
    }
}
