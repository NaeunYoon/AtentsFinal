#include "CustomList.h"
#include<iostream>
using namespace std;

CustomList::CustomList() {
	pHead = new Node();
	pTail = new Node();

	pHead->pPrev = pHead;
	pHead->pNext = pTail;
	pTail->pPrev = pHead;
	pTail->pNext = pTail;
}

CustomList :: ~CustomList() {
	if (pHead != nullptr) {
		delete pHead;
	}

	if (pTail != nullptr) {
		delete pTail;
	}
}

void CustomList::Insert(Node * _pNewNode,Node* _t) 
{
	_t->pPrev->pNext = _pNewNode;
	_pNewNode->pPrev = _t->pPrev;
	_t->pPrev = _pNewNode;
	_pNewNode->pNext = _t;

}

Node* CustomList::Find(int _findData)
{
	return nullptr;
}
void CustomList::Remove(int _removeData)
{

}
void CustomList::DisplayData()
{
	Node* tmp = pHead->pNext;
	while (tmp != pTail) {
		cout << "Data = " << tmp->data << endl;
		tmp = tmp->pNext;
	}
}


