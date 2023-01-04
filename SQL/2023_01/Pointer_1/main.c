#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

//구조체형 데이터 타입을 만듬
struct Student
{
	char name[30];	//구조체 멤버
	int age;
	int gender;
	char phoneNum[20];
};

int main() {
	//학생 관리 프로그램

	char name[30];
	int age;
	int gender;
	char phoneNum[12];

	//학생이 1명인가요?
	//100명이라고 하자
	//100명의 학생을 만들기 위한 저장공간 100개
	//서로 연관성 있는 데이터를 하나로 묶이서 새로운 데이터 타입을 만들 수 있다 => 구조체
	struct Student a;	//구조체 안의 멤버를 접근할 때 . (period 연산자)를 사용
	a.age = 10;

	//구조체 변수의 주소값으로 접근할 때? -> (화살표 연산자)를 사용
	(&a)->age=10;
	struct Student array[100];
	//이 요소의 데이터 타입이 Student 구조체고, 그 한 칸마다 구조체를 담을 수 있다
	//한 칸은 4개의 공간으로 나뉘어져 있다
	int length = sizeof(array) / sizeof(array[0]);
	for (int i = 0; i < length; i++)
	{
		sprintf(array[i].name,"monster+%d",i);
		array[i].age = i % 5 + 10;
		array[i].gender = i % 2;
		sprintf(array[i].phoneNum,"010-0000-0000",i);
	}
	for (int i = 0; i < length; i++)
	{
		print("이름",array[i].name);
		print("나이",array[i].age);
		print("성별",array[i].gender);
		print("번호", array[i].phoneNum);
	}


	return 0;
}