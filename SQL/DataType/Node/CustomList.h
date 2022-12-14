#pragma once

struct Node {
	int data;
	Node* pNext;
	Node* pPrev;
};

class CustomList {
public :
	Node* pHead;
	Node* pTail;

public: 
		CustomList() {};	//생성자
		~CustomList();		//소멸자

		  void Insert(Node* _pNewNode,Node* _t);	//데이터 삽입
		  Node* Find(int _findData);		//데이터 검색
		  void Remove(int _removeData);	//데이터 삭제
		  void DisplayData();

};
