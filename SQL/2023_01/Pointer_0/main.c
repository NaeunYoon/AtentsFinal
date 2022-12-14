#include<stdio.h>


void Swap(int a, int b)	//매개변수 
{

	int tmp = 0;
	tmp = a;
	a = b;
	b = tmp;
}

void Pswap(int* a, int* b)	//매개변수 
{

	int tmp = 0;
	tmp = *a;
	*a = *b;
	*b = tmp;
}

int main() {

	int a = 20;
	int b = 30;
	printf("a = %d, b = %d\n", a, b);
	Swap(a, b);	//인자
	printf("a = %d, b = %d\n", a, b);
	//a와 b의 값이 안바뀐다 (값이 전달되는거고 공간은 서로 다름)
	Pswap(&a, &b);
	printf("a = %d, b = %d\n", a, b);
	//a,b가 메인에서 만들어지고 Pswap을 호출하는데, 주소값을 전달한다
	//그러면 매개변수가 만들어지는데 int형 주소값을 저장하는 변수들이 만들어진다
	//주소값이 전달이 된다. int* a = &a, int* b = &b 이렇게 된다 (주소값 호출)
	//주소값 앞에 *a 면 a가 가지고 있는 값이다
	//메모리 공간은 main에 있는 a 변수에 접근하게 된 것이다
	//*b 는 b변수가 가지고 있는 값에 포인터 연산자 => main에 있는 b 변수의 주소값
	//거기에 있는 포인터 연산자는 b 이다

	//동일한 데이터 타입의 공간이 여러개 필요할 때
	//0~100 사이의 숫자를 저장하세요
	//int a0 = 0; int a1 = 1;...
	//여기에서 짝수만 출력하세요
	//if(a0 %2 ==0){print("짝수입니다");}...

	//이럴 때 배열을 쓴다

	int arr[101];
	//int 값 저장공간 101개 만들어라 (404 바이트의 공간을 뭉탱이로 할당한다)
	//배열명 : 주소상수 ( 나중에 배열이 할당된 선두번지 주소값으로 변한다)
	//arr[0];		//배열식 ( 선두번지 주소값으로부터 0칸 떨어진 곳) : 2000번지 값은 100
	//arr[1];		//(선두번지 주소값으로부터 1칸 떨어진 곳) : 2000 + 1*4 = 2004번지 값은 200
	//배열식을 사용할 수 있다 보니까 반복문을 사용할 수 있다
	for (int i = 0; i < 101; i++)
	{
		arr[i] = i;
		printf("arr[%d] = %d\n",arr[i],i);
	}






	return 0;
}