#include <stdio.h>

int main() {

	int a;	//a라는 변수에 20이 들어가 있다 (메모리에 할당되기 때문에 주소값을 가지고 있다)
	//변수명은 나중에 실행될 때 할당될 메모리 공간을 대신하고 있습니다
	a = 20;
	printf("&a = %p\n", &a);	//a의 주소값
	int* pa;	//&a를 가지고 있는 포인터 변수 (포인터 형 지정자) * : 주소를 저장할 때
				//a의 주소값을 가지고 있는 공간의 주소값은 int형 포인터
	//int*값을 저장하기 위한 pa변수를 만들고 a변수의 주소값을 만들음
	pa = &a;
	printf("pa =%p\n", pa);	//a의 주소값을 가지는 포인터 변수 pa
	int** ppa; //&a를 가지고 있는 &pa를 가지고 있는 변수 
				//pa도 주소값을 가지고 있고 pa의 주소값을 저장하고 싶음
				//a의 주소값을 가지고 있는 데이터타입 (int*)의 포인터기 때문에 int**가 ppa의 데이터타입
				//pa안엔 &a (a의 주소값을 가지고 있음)
	ppa = &pa;
	printf("ppa =%p\n", ppa);	//pa의 주소값을 가지는 포인터 변수 ppa











	int*** pppa;
	pppa = &ppa;
	printf("pppa =%p\n", pppa);	//ppa의 주소값을 가지는 포인터 변수 pppa

	**ppa; //pppa가 가지고 있는 값 (pa의 주소값)
	**&pa; //공간의 값 => pa변수
	*pa;
	*&a;
	a;
	printf("&**ppa = %p, &**&pa = %p, &*pa =%p,&*&a =%p,&a=%p\n", &**ppa, &**&pa, &*pa, &*&a, &a);
	printf("**ppa = %d, **&pa = %d, *pa =%d,*&a =%d,a=%d\n", **ppa, **&pa, *pa, *&a, a);


	return 0;
}