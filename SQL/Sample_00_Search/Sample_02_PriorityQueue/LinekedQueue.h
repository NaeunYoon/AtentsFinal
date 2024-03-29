#ifndef LINKED_QUEUE_H
#define LINKED_QUEUE_H

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef struct tagNode
{
    char* Data;
    int Priority;   //노드에 우선순위 추가
    struct tagNode* PrevNode;
    struct tagNode* NextNode;
} Node;

typedef struct tagLinkedQueue
{
    Node* Front;
    Node* Rear;
    int   Count;
} LinkedQueue;

void  LQ_CreateQueue(LinkedQueue** Queue);
void  LQ_DestroyQueue(LinkedQueue* Queue);

//Priority  추가
Node* LQ_CreateNode(char* Data, int priority);
void  LQ_DestroyNode(Node* _Node);

void  LQ_Enqueue(LinkedQueue* Queue, Node* NewNode);
Node* LQ_Dequeue(LinkedQueue* Queue);

int   LQ_IsEmpty(LinkedQueue* Queue);

#endif LINKED_QUEUE_H