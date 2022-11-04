// BitFeldExample.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;
struct DATA {
    unsigned int a : 8;
    unsigned int b : 8;
    unsigned int c : 8;
    unsigned int d : 8;
};

union uDATA {
    int a;
    unsigned char b;
    double c;
};

union uUSERDATA {
    
    DATA _d;
    unsigned int _u; //두개의 데이터는 메모리를 공유한다 udata를 갖고오면 data를 가져오는거임
};


int main()
{
    std::cout << "Hello World!\n";

    DATA data;
    printf("Data의 크기 = %d\n", sizeof(DATA));
    cout << "Data의 크기" << sizeof(data) << "바이트입니다\n" << endl;


    uDATA uData;
    uData.a = 100;
    uData.b = 200;
    uData.c = 300;

    cout << "uData의 크기" << uData.a<< endl;

    cout << "uData의 크기" << uData.b << endl;

    cout << "uData의 크기" << uData.c << endl;

    //

    uUSERDATA _data;

    _data._d.a = 100;
    _data._d.b = 200;
    _data._d.c = 300;
    _data._d.c = 400;
    
    cout << _data._u << endl;

    uUSERDATA _copyData;
    _copyData._u = _data._u;

    cout << _copyData._d.a << endl;
    cout << _copyData._d.b << endl;
    cout << _copyData._d.c << endl;
    cout << _copyData._d.d << endl;


}

// 프로그램 실행: <Ctrl+F5> 또는 [디버그] > [디버깅하지 않고 시작] 메뉴
// 프로그램 디버그: <F5> 키 또는 [디버그] > [디버깅 시작] 메뉴

// 시작을 위한 팁: 
//   1. [솔루션 탐색기] 창을 사용하여 파일을 추가/관리합니다.
//   2. [팀 탐색기] 창을 사용하여 소스 제어에 연결합니다.
//   3. [출력] 창을 사용하여 빌드 출력 및 기타 메시지를 확인합니다.
//   4. [오류 목록] 창을 사용하여 오류를 봅니다.
//   5. [프로젝트] > [새 항목 추가]로 이동하여 새 코드 파일을 만들거나, [프로젝트] > [기존 항목 추가]로 이동하여 기존 코드 파일을 프로젝트에 추가합니다.
//   6. 나중에 이 프로젝트를 다시 열려면 [파일] > [열기] > [프로젝트]로 이동하고 .sln 파일을 선택합니다.
