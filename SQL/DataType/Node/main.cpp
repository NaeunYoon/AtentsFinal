#include<iostream>
#include "CustomList.h"
using namespace std;



int main() {
	CustomList* pList = new CustomList();

	for (int i = 0; i < 10; i++)
	{
		Node* pNewData = new Node;
		pNewData->data = i;
		pList->Insert(pNewData, pList->pTail);
	}

	pList->DisplayData();
	pList->Remove(3);
	Node* findData = pList->Find(3);

	if (findData != nullptr) {
		cout << "검색한 결과 = " << findData->data << endl;
	}

	//데이터 추가
	pList->PushFront(100);
	pList->PushFront(101);
	pList->PushFront(102);
	pList->PushBack(1000);
	pList->PushBack(1001);
	pList->PushBack(1002);
	pList->DisplayData();

	pList->DeleteAll();
	if (pList != nullptr) {
		delete pList;
	}

	

}