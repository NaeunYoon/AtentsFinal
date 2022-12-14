#include<iostream>
#define ARRAY_LENGTH 6
using namespace std;

struct Node {
	int data;
	Node* pNext;
	Node* pPrev;
};

int main() {
	//포인터를 사용하여 크기가 6인 정수형 배열을 선언하고,
	//값을 -1로 초기화하세요

	int* arr = new int[ARRAY_LENGTH];

	for (int i = 0; i < ARRAY_LENGTH; i++)
	{
		arr[i] = -1;
	}
	if (arr != nullptr) {
		delete[] arr;
	}

	//포인터 변수를 저장할 크기가 6인 배열을 선언하시오
	int array[6];
	array[0] = 100;
	cout << "배열에 저장된 값" << array[0] << endl;
	cout << "배열의 시작주소값" << &array[0] << endl;
	int* pArray[6];
	for (int i = 0; i < ARRAY_LENGTH; i++)
	{
		pArray[i] = new int;
		cout << pArray[i] << endl;
	}
	for (int i = 0; i < ARRAY_LENGTH; i++)
	{
		*pArray[i] = i;
		cout << *pArray[i] << endl;
	}
	cout << "배열에 저장된 값" << pArray[0] << endl;
	cout << "배열의 주소에 저장된 값" << *pArray[0] << endl;
	for (int i = 0; i < ARRAY_LENGTH; i++)
	{
		delete pArray[i];
	}
	//
	Node* pHead = new Node;
	Node* pTail = new Node;
	pHead->pNext = pTail;
	pHead->pPrev = nullptr;
	pHead->pNext = nullptr;
	pTail->pPrev = pHead;

	Node* pNewNode = new Node;
	pNewNode->data = 100;
	pHead->pNext = pNewNode;
	pHead->pNext->pPrev = pHead;
	pHead->pNext->pNext = pTail;
	pHead->pNext->pNext->pPrev = pNewNode;
	//pNewNode의 데이터를 가르킨다
	cout << pNewNode -> data << endl;
	cout << pNewNode->pNext->pPrev->data << endl;
	cout << pHead->pNext->data << endl;
	cout << pHead->pNext->pNext->pPrev->data << endl;
	//pTail->pPrev = pNewNode;

}


