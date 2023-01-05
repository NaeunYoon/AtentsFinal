#ifndef LINKEDLIST_H
#define LINKEDLIST_H

#include <stdio.h>
#include <stdlib.h>

typedef int ElementType;    //element type 은 int형이다

typedef struct tagNode  //노트타입을 만든거다.
{
    ElementType Data;   //데이터
    struct tagNode* NextNode;   //자기자신의 타입에 주소값을 저장하는 NextNode (다음 노드의 주소값을 저장)
} Node;

/* 함수 원형 선언 */
Node* SLL_CreateNode(ElementType NewData);  //노드를 만드는 함수
void  SLL_DestroyNode(Node* Node);  //노드를 없애는 함수
void  SLL_AppendNode(Node** Head, Node* NewNode);   //노드를 추가하는 함수
void  SLL_InsertAfter(Node* Current, Node* NewNode);    //새로운 노드 삽입
void  SLL_InsertNewHead(Node** Head, Node* NewHead);    //노드를 새로운 헤드로 만드는 함수
void  SLL_RemoveNode(Node** Head, Node* Remove);    //노드를 제거하는 함수
Node* SLL_GetNodeAt(Node* Head, int Location);  //헤드에서부터 몇 번째 노드의 주소값을 찾는 함수
int   SLL_GetNodeCount(Node* Head); //노드의 갯수가 몇개인지 세어주는 함수

#endif
