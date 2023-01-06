#pragma once
#include "LinkedList.h"

/*  ��� ���� */
Node* SLL_CreateNode(ElementType NewData) 
{

	Node* NewNode = (Node*)malloc(sizeof(Node));

	if (NewNode != NULL) {
		/*  �����͸� �����Ѵ�. */
		NewNode->Data = NewData;	//�����͸� �����Ѵ�(0,1,2,3,4)
		/*  ���� ��忡 ���� �����ʹ� NULL�� �ʱ�ȭ �Ѵ�. */
		NewNode->NextNode = NULL;	
		//�ּҰ��� ����� ���� ���� ������ null�̶�� �Ѵ�
		//�ּҰ��� ����� ������ 0�� null�̴�
	}
	/*  ����� �ּҸ� ��ȯ�Ѵ�. */
	return NewNode;	
}
/*  ��� �Ҹ� */
void SLL_DestroyNode(Node* Node) 
{
	free(Node);
}
/*  ��� �߰� */
void SLL_AppendNode(Node** Head, Node* NewNode) 
{	//����Ʈ�� �ּҰ��� �ޱ� ������ node**
	/*  ��� ��尡 NULL�̶�� ���ο� ��尡 Head */
	//*Head : ���ο� �ִ� ����Ʈ ������ �ּҰ��� ������ ������(*&List) -> ���ο� �ִ� ����Ʈ ����
	//���ο� �ִ� ����Ʈ ������ ���� null�̳İ� ���� ( ����Ʈ ������ �� �������? -> ������� �ּҰ��� �����Ϸ���)
	//���ο� �ִ� ����Ʈ �ּҿ� ����Ȱ� �ƹ��� ����? ��� ���� => �پ��ִ� ��尡 �ƹ��͵� �����Ƿ�
	//���Ӱ� ������� �ּҰ��� �־��ش�
	if ((*Head) == NULL) {	//���ο� �ִ� ����Ʈ ������ 0�̴�?
		*Head = NewNode;	//����带 �Ҵ��� ( �� ó�� ������� 0�� ���� �ִ� ��尡 ��� ��尡 �ȴ�)
	}
	/*  ������ ã�� NewNode�� �����Ѵ�. */
	else 
	{	//������ ã�� newNode�� �����Ѵ�
		Node* Tail = (*Head);
		while (Tail->NextNode !=NULL)
		{
			Tail = Tail->NextNode;
		}
		Tail->NextNode = NewNode;
	}
}
/*  ��� ���� */
void SLL_InsertAfter(Node* Current, Node* NewNode) {

	NewNode->NextNode = Current->NextNode;
	Current->NextNode = NewNode;
}

void SLL_InsertNewHead(Node** Head, Node* NewHead) {
	if (*Head == NULL) 
	{
		(*Head) = NewHead;
	}
	else
	{
		NewHead->NextNode = (*Head);
		(*Head) = NewHead;
	}
}
/*  ��� ���� */
void SLL_RemoveNode(Node** Head, Node* Remove) {
	if (*Head == Remove) 
	{
		*Head = Remove->NextNode;
	}
	else 
	{
		Node* Current = *Head;
		while (Current != NULL && Current->NextNode != Remove) 
		{
			Current = Current->NextNode;
		}
		if (Current != NULL) {
			Current->NextNode = Remove->NextNode;
		}
		
	}
}
/*  ��� Ž�� */
Node* SLL_GetNodeAt(Node* Head, int Location) 
{
	Node* Current = Head;

	while (Current !=NULL&&(--Location)>=0)
	{
		Current = Current->NextNode;
	}
	return Current;
}
/*  ��� �� ���� */
int SLL_GetNodeCount(Node* Head) 
{
	int Count = 0;
	Node* Current = Head;
	while (Current != NULL)
	{
		Current = Current->NextNode;
		Count++;
	}
	return Count;
}