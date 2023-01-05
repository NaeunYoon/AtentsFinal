#ifndef LINKEDLIST_H
#define LINKEDLIST_H

#include <stdio.h>
#include <stdlib.h>

typedef int ElementType;    //element type �� int���̴�

typedef struct tagNode  //��ƮŸ���� ����Ŵ�.
{
    ElementType Data;   //������
    struct tagNode* NextNode;   //�ڱ��ڽ��� Ÿ�Կ� �ּҰ��� �����ϴ� NextNode (���� ����� �ּҰ��� ����)
} Node;

/* �Լ� ���� ���� */
Node* SLL_CreateNode(ElementType NewData);  //��带 ����� �Լ�
void  SLL_DestroyNode(Node* Node);  //��带 ���ִ� �Լ�
void  SLL_AppendNode(Node** Head, Node* NewNode);   //��带 �߰��ϴ� �Լ�
void  SLL_InsertAfter(Node* Current, Node* NewNode);    //���ο� ��� ����
void  SLL_InsertNewHead(Node** Head, Node* NewHead);    //��带 ���ο� ���� ����� �Լ�
void  SLL_RemoveNode(Node** Head, Node* Remove);    //��带 �����ϴ� �Լ�
Node* SLL_GetNodeAt(Node* Head, int Location);  //��忡������ �� ��° ����� �ּҰ��� ã�� �Լ�
int   SLL_GetNodeCount(Node* Head); //����� ������ ����� �����ִ� �Լ�

#endif
