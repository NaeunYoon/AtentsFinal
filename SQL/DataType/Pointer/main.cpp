#include<iostream>
#define ARRAY_LENGTH 6
using namespace std;

struct Node {
	int data;
	Node* pNext;
	Node* pPrev;
};

int main() {
	//�����͸� ����Ͽ� ũ�Ⱑ 6�� ������ �迭�� �����ϰ�,
	//���� -1�� �ʱ�ȭ�ϼ���

	int* arr = new int[ARRAY_LENGTH];

	for (int i = 0; i < ARRAY_LENGTH; i++)
	{
		arr[i] = -1;
	}
	if (arr != nullptr) {
		delete[] arr;
	}

	//������ ������ ������ ũ�Ⱑ 6�� �迭�� �����Ͻÿ�
	int array[6];
	array[0] = 100;
	cout << "�迭�� ����� ��" << array[0] << endl;
	cout << "�迭�� �����ּҰ�" << &array[0] << endl;
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
	cout << "�迭�� ����� ��" << pArray[0] << endl;
	cout << "�迭�� �ּҿ� ����� ��" << *pArray[0] << endl;
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
	//pNewNode�� �����͸� ����Ų��
	cout << pNewNode -> data << endl;
	cout << pNewNode->pNext->pPrev->data << endl;
	cout << pHead->pNext->data << endl;
	cout << pHead->pNext->pNext->pPrev->data << endl;
	//pTail->pPrev = pNewNode;

}


