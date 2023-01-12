#ifndef LINKEDLIST_STACK_H
#define LINKEDLIST_STACK_H

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef struct tagNode
{
    char* Data;
    struct tagNode* NextNode;

    struct tagNode* PrevNode;//이전 노드의 주소값

} Node;

typedef struct tagLinkedListStack
{
    Node* List;	// 헤드노드 주소값
    Node* Top;	// 꼬리 노드 주소값

    int Count;  //스택의 노드 갯수를 카운팅

} LinkedListStack;

void  LLS_CreateStack(LinkedListStack** Stack);
void  LLS_DestroyStack(LinkedListStack* Stack);

Node* LLS_CreateNode(char* Data);
void  LLS_DestroyNode(Node* _Node);

void  LLS_Push(LinkedListStack* Stack, Node* NewNode);
Node* LLS_Pop(LinkedListStack* Stack);

Node* LLS_Top(LinkedListStack* Stack);
int   LLS_GetSize(LinkedListStack* Stack);
int   LLS_IsEmpty(LinkedListStack* Stack);



#endif // !LINKEDLIST_STACK_H
