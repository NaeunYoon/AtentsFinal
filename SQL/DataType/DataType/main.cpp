#include <iostream>
using namespace std;
int main() {
	/*
	%d : 부호 있는 10진수 정수 (char short int)
	%ld : 부호 있는 10진수 정수 (long)
	%lld : 부호 있는 10진수 정수 (long long)
	%u : 부호 없는 10진수 정수 (unsigned int)
	%o : 부호 없는 8진수 정수 ( unsigned int)
	%x : 부호 없는 16진수 정수 (insigned int)
	%s : 문자열
	%6d : 출력의 폭을 6칸으로 지정하고 남은 공간을 0으로 채움
	%f : 실수출력
	%.2f : 소수 둘쨰자리까지 출력
	%010 2f : 출력 폭은 10칸, 소수 둘쨋자리까지 출력, 남은 공간은 0으로 채움
	%x : 16진수 출력
	%#x : 앞에0x 를 붙여 출력 (소문자)
	%#X : 앞에 0X를 붙여 출력 (대문자)
	:: ~안에 라는 뜻
	<< printf
	>> scanf

	//byte 는 존재하지 않는다
	//string 은 없다
	*/
	
	std::cout << "HelloWorld\n";

	int i = 100;	//4바이트
	unsigned int ii = 101;
	short s = 100;
	unsigned char c = 'a'; //0~255 표현범위
	string str = "안녕하세요";
	bool b = true;
	__int8 i8 = 10;
	unsigned __int8 ii8 = 200;
	__int16 i16 = 16;	//2바이트
	__int32 i32 = 32;	//4바이트 = int
	__int64 i64 = 32;	//8바이트 = long long
	long long l = 200;
	char ar[] = "안녕하세요";
	char arr[12] = "안녕하세요";

	printf("%d\n", i);
	printf("%d\n", ii);
	printf("%d\n", s);
	printf("%c\n", c);
	printf("%s\n", str.c_str());		//c_str : 문자열
	printf("%d\n", b);
	printf("%d\n", i8);
	printf("%d\n", ii8);
	printf("%d\n", i16);
	printf("%d\n", i32);
	printf("%lld\n", i64);
	printf("%lld\n", l);
	printf("%s\n", arr);
	printf("%s\n", ar);

	cout << "boolType =" << b << endl;


	//포인터 : 메모리의 주소값을 저장할 수 있는 변수
	//실제 데이터가 저장된 주소를 저장
	//포인터 변수를 사용하기 위해서는 메모리를 할당해야 한다
	//포인터 변수를 사용하는 이유는 변수의 크기가 실제 데이터와 상관없이 4바이트이기 때문이다
	//빌드 시 포인터변수는 실행파일에서 4바이트 크기로 비드된다.
	int* pData = new int;	//정수형 포인터 변수 pData
	//int 만큼의 크기의 메모리를 할당하고 메모리의 시작 주소를 반환하는데 그게 pData에 저장
	//따라서 pData는 메모리의 주소값이 되다
	//new를 사용했다면 메모리를 해제해줘야한다. 반환해주기 위해 delete를 해준다
	*pData = 100;	//메모리 주소에 있는 값
	cout << "pData 가 가리키는 메모리 주소에 저장된 값 = " << *pData << endl;
	cout << "실제 데이터의 메모리 주소값 = " << pData << endl;
	if (pData != nullptr)	//nullptr 또는 NULL 
	{
		delete pData;	//포인터변수는 꼭 delete를 해줘야한다
		pData = nullptr;	//다음에 pData를 사용하기 위해서 널로 초기화해준다
	}
	/*
	변수 8바이트 짜리를 포인터 변수를 사용하지 않으면 빌드할 떄 8바이트 그대로 저장
	변수는 실제로 메모리 주소를 포함하고 있음
	그러나 포인터를 사용하면 4바이트로 빌드할 때 포함되고 나머지는 나중에 할당
	
	*/

	//일반변수의 메모리 주소값
	cout << "i의 메모리 주소 = " << &i << endl;
	int* p = &i;	//p는 저장할 수 있는게 오로지 메모리 주소값 (가능)
	//이걸 우리는 참조라고 한다

	//p가 가르치는건 메모리 주소, 주소값을 가리키는건 시작점이다
	cout << "원래 i의 값 = " << i << endl;
	*p = 1000;
	//메모리 주소가 가르치는 값 => i값도 같이 변경

	cout << "i는 동일한 메모리를 가리키고 있고 i가 가르키는 값을 변경함 " << i << endl;

	// int* p1 = 100; //주소값을 넣어야 함 ( 값이 아님 ), 넣고싶으면?

	int* p1;
	p1 = new int;
	*p1 = 200;
	if (p1 != NULL) {
		delete p1;
		p1 = NULL;
	}

	// & 참조연산자 ( 실제 일반  변수에는 메모리 주소값이 포함되어 있다)

	int _i = 200;
	cout << &_i << endl;
	//이중포인터 (2차원 배열과 동일하다)
	//포인터 하나가 있을 때에는 메모리 주소
	//포인터 두개가 있을 때에는 메모리 주소를 저장하고 메모리 주소를 따라가보니 데이터가 존재함
	//주소의 주소를 따라가는 것

	printf("\ntest\n");
	int* p2;
	p2 = new int;
	cout << "(메모리 할당한 p2 포인터 )new int = " << p2 << endl;
	*p2 = 365;
	cout << "(p2 포인터가 가지고 있는 값)*p2 = " << *p2 << endl;

	cout << "(p2 포인터의 주소값) &p2 = " << &p2 << endl;
	int** ppa = &p2;
	cout << "(p2 포인터의 주소값을 이중포인터에 넣음) &p2 = " <<ppa << endl;
	printf("\ntest\n");


	int** pp = new int*[3];
	for (int i = 0; i < 3; i++)
	{
		pp[i] = new int[3];
	}
	pp[0][0] = 100;
	pp[0][1] = 200;
	pp[0][2] = 300;

	for (int i = 0; i < 3; i++)
	{
		delete[] pp[i];
	}
	delete[] pp;

	//포인터와 배열의 관계
	int* pb = new int[4];
	pb[0] = 0;
	pb[1] = 1;
	pb[2] = 2;
	pb[3] = 3;
	cout << "pb[0] = " << pb[0] << endl;
	cout << "pb[1] = " << pb[1] << endl;
	cout << "pb[2] = " << pb[2] << endl;
	cout << "pb[3] = " << pb[3] << endl;

	cout << "pb[0]의 주소값 = " << &pb[0] << endl;
	cout << "pb가 의미하는 것은 &pb[0]과 동일하다" << pb << endl;

	if (pb != nullptr) {
		delete[] pb;
		pb = nullptr;
	}

	//pb의 값을 포인터 연산자를 사용해서 값을 대입
	*(pb + 0) = 1000;	//4바이트씩 건너뛰기
	*(pb + 1) = 2000;
	*(pb + 2) = 3000;
	*(pb + 3) = 4000;

	//변수에 저장된 메모리 주소의 더하기의 의미는 = ? +1 의 의미는 다음 블럭의 주소를 의미
	//(저장된 자료형의 크기만큼을 더한 오프셋의 주소)

	for (int i = 0; i < 4; i++)
	{
		//foreach . length 없기 때문에 데이터 크기로 계산한다
		cout << *(pb + i) << endl;
	}

	
}