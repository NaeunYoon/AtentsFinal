using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend
{
    class TV
    {
        private string _brandName;
        private bool _isoper;
        private int _currentChannel;
        private int _currentSound;

        public TV() : this("미정",false,0,0)
        {

        }

        public TV(string brandName, bool isoper, int currentChannel, int currentSound)
        {
            _brandName = brandName;
            _isoper = isoper;
            _currentChannel = currentChannel;
            _currentSound = currentSound;
        }

        public TV(TV value) //복사생성자 : 자신의 데이터 타입을 인자로 받는 생성자 ( 복사생성자는 자동으로 안만들어줌)
        {   //객체는 다르지만 같은 데이터 타입 같은 클래스라서 접근이 가능하다
            _brandName = value._brandName;
            _isoper = value._isoper;    
            _currentChannel = value._currentChannel;
            _isoper = value._isoper;
        }

        public void ChannelUp()
        {
            _currentChannel +=1;
        }

        public void ChannelDown()
        {
            _currentChannel -=1;
        }

        public void VolumnUp()
        {
            _currentSound +=1;
        }

        public void VolumndDown()
        {
            _currentSound -=1;
        }

        public void SetOn()
        {
            _isoper = true;
        }

        public void SetOff()
        {
            _isoper = false;
        }
        public void Info()
        {
            Console.WriteLine($"브랜드명{0}\n, 현재 채널 번호 : {1}\n, 볼륨레벨 {2}\n",_brandName,_currentChannel,_currentSound);

            if (_isoper)
            {
                Console.WriteLine("작동중\n");
            }
            else
            {
                Console.WriteLine("작동안함\n");
            }
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TV tv = new TV("LG올레드", true, 0, 0);
            tv.ChannelUp();
            tv.VolumnUp();
            tv.Info();

            TV tv1 = new TV(tv); //복사생성자 자기 자신의 타입을 인자로 받음 (자기 자신의 데이터 타입)
            tv1.Info();

            tv1.ChannelUp();
            tv.ChannelUp();

            Console.WriteLine("tv");
            tv.Info();

            Console.WriteLine("tv1");
            tv1.Info();
        }
    }
}
