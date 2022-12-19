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
	Node* tmp = pHead->pNext;
	while (tmp != pTail) {
		if (tmp->data == _findData) {
			return tmp;
		}
		tmp = tmp->pNext;
	}return nullptr;
}
void CustomList::Remove(int _removeData)
{
	Node* tmp = pHead->pNext;
	Node* findNode = nullptr;
	while (tmp != pTail) {
		if (tmp->data == _removeData) {
			
			findNode = tmp;
			break;
		}
		tmp = tmp->pNext;
	}

	if (findNode != nullptr) {
		findNode->pPrev->pNext = findNode->pNext;	//1번과 f 2번을 연결할 코드
		findNode->pNext->pPrev = findNode->pPrev;	//2번과 f 1번을 연결할 코드
		delete findNode;
	}
}

void CustomList::DeleteAll() {

	Node* s;
	Node* tmp;
	s = pHead->pNext;
	while (s != pTail) {
		tmp = s;
		s = s->pNext;
		cout << "지운데이터" << tmp->data << endl;
		tmp->pPrev->pNext = tmp->pNext;
		tmp->pNext->pPrev = tmp->pPrev;
		tmp->pNext = nullptr;
		tmp->pPrev = nullptr;
		delete tmp;
	}
}

void CustomList::DisplayData()
{
	Node* tmp = pHead->pNext;
	while (tmp != pTail) {
		cout << "Data = " << tmp->data << endl;
		tmp = tmp->pNext;
	}
}

//pHead 다음에 데이터 노드를 추가
void CustomList::PushFront(Node* _pNewNode)
{
	//우측 포인터 관계 정리
	pHead->pNext->pPrev = _pNewNode;
	_pNewNode->pNext = pHead->pNext;
	//좌측 포인터 관계 정리
	pHead->pNext = _pNewNode;
	_pNewNode->pPrev = pHead;
}
void CustomList::PushFront(int _pNewData)
{
	Node* pNewNode = new Node;
	pNewNode->pNext = pHead->pNext;
	//우측 포인터 관계 정리
	pHead->pNext->pPrev = pNewNode;
	pNewNode->pNext = pHead->pNext;
	//좌측 포인터 관계 정리
	pHead->pNext = pNewNode;
	pNewNode->pPrev = pHead;
}
//pHead 다음에 데이터 노드를 추가
void CustomList::PushBack(Node* _pNewNode)
{
	//좌측 포인터 관계
	pTail->pPrev->pNext = _pNewNode;
	_pNewNode->pPrev = pTail->pPrev;
	//우측 포인터 관계
	_pNewNode->pNext = pTail;
	pTail->pPrev = _pNewNode;
}
void CustomList::PushBack(int _pNewData)
{
	Node* pNewNode = new Node;
	pNewNode->pNext = pHead->pNext;
	//좌측 포인터 관계
	pTail->pPrev->pNext = pNewNode;
	pNewNode->pPrev = pTail->pPrev;
	//우측 포인터 관계
	pNewNode->pNext = pTail;
	pTail->pPrev = pNewNode;
}


