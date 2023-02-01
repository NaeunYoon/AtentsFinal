#ifndef DOUBLY_LINKEDLIST_H
#define DOUBLY_LINKEDLIST_H
#include "Score.h"
#include <stdio.h>
#include <stdlib.h>

typedef Score ElementType;

typedef struct tagNode
{
    ElementType Data;   //결론적으로 int Data
    struct tagNode* PrevNode;
    struct tagNode* NextNode;
} Node;
//노드라는 이름으로 사용할 수 있게 TYPEDF로 재정의

/* 함수 원형 선언 */
Node* DLL_CreateNode( ElementType NewData );
void  DLL_DestroyNode( Node* Node);
void  DLL_AppendNode( Node** Head, Node* NewNode );
void  DLL_InsertAfter( Node* Current, Node* NewNode );
void  DLL_RemoveNode( Node** Head, Node* Remove );
Node* DLL_GetNodeAt( Node* Head, int Location );
int   DLL_GetNodeCount( Node* Head );

#endif DOUBLY_LINKEDLIST_H