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
		CustomList() {};	//������
		~CustomList();		//�Ҹ���

		  void Insert(Node* _pNewNode,Node* _t);	//������ ����
		  Node* Find(int _findData);		//������ �˻�
		  void Remove(int _removeData);	//������ ����
		  void DisplayData();

};
