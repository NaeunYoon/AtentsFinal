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
		CustomList();	//생성자
		~CustomList();		//소멸자

		  void Insert(Node* _pNewNode,Node* _t);	//데이터 삽입
		  Node* Find(int _findData);		//데이터 검색
		  void Remove(int _removeData);	//데이터 삭제
		  void DeleteAll();	//데이터 노드 모두 삭제
		  void DisplayData();	//데이터 보여주기
		  void PushFront(Node* _pNewNode);	//Head  뒤에 데이터 추가
		  void PushFront(int _pNewData);	//오버로드
		  void PushBack(Node* _pNewNode);	//Tail 앞에 데이터를 추가
		  void PushBack(int _pNewData);	//Tail 앞에 데이터를 추가

};
