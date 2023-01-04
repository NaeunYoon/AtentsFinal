#include<stdio.h>

int global = 20;	//외부변수, 전역변수
int SetScore(int value) 
{
	static int score = 0; //정적변수 : 없어지지 않는다 ( 함수 블럭이 닫혀도 안없어짐)
							//함수가 한번 만들어지면 생성되고 사라지지 않는다
	global = 100;
	score += value;
	return score;
}

int main() {

	int a;
	a = 20;
	{
		int a = 100;	//자동변수 ( 중괄호 나가면 사라짐)
	}

	for (int i = 0; i < 100; i++)
	{
		SetScore(i);
	}
	int ret = SetScore(0);
	printf("ret = %d", ret);
	//===========================================================
	int* pa =(int*)malloc(100);	//동적메모리 공간 할당

	 for (int i = 0; i < 25; i++)
	 {
		 pa[i] = i;
	 }

	 for (int i = 0; i < 25; i++)
	 {
		 printf("pa[%d] = %d\n", i, pa[i]);
	 }

	 free(pa);	//동적메모리 공간 반환처리

	return 0;

	//malloc calloc realloc 을 사용해서 메모리 할당
	//free 를 통해 반환한다
	//반드시 동적메모리 공간은 반환을 해줘야 한다.
}