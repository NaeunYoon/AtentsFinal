using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_00
{
    /* 소켓 프로그래밍 통신 절차
     
     서버 : 소켓생성 ,  bind, listen, accept 호출
            bind : 종단점에 ip와 포트를 묶어준다 
            listen : 포트가 연결을 받을 수 있도록 시스템에 알려준다
     클라이언트 : 소켓 생성 (서버 ip와 포트를 알고 있어야 한ㄷㅏ : 서버에 접속하는거라 종단점 필요) 
                  connect 함수 호출 (accept가 호출되 ㄴ상태에서 커넥트 요청이 있으면 소켓 반환함)
                                    (원격 호스트(내가 통신하고자 하는 pc) 에 대한 연결을 설정)

                  accept 함수가 할당된 새로운 소켓으로 서버는 클라이언트와 통신한다 (클라이언트와 통신하는 유일한 도구임)
                  : 1000명의 유저가 접속했다면 1000개의 소켓이 필요

    소켓(socket) 을 이용해서 데이터를 바이트 단위로 보내고 받기 ( 송신, 수신 )
    송신함수 : send()
    수신 : receive()
     
    begin 이 붙으면 ?
    
    BeginSend : 샌드 후에 요청에 대한 결과가 와야 답을 진행하는게 아님 ( 비동기), 
                요청 하고 나는 나대로 진행하다가 요청에 대한 결과가 오면 콜백처리함
    Send : 송신의 결과가 모두 반환된 후에 다음으로 진행
     */
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
