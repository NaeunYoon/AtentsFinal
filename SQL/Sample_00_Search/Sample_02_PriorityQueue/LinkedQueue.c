#define _CRT_SECURE_NO_WARNINGS
#include "LinekedQueue.h"

void  LQ_CreateQueue(LinkedQueue** Queue)
{
    /*  ť�� ��������ҿ� ���� */
    (*Queue) = (LinkedQueue*)malloc(sizeof(LinkedQueue));
    (*Queue)->Front = NULL;
    (*Queue)->Rear = NULL;
    (*Queue)->Count = 0;
}

void LQ_DestroyQueue(LinkedQueue* Queue)
{
    while (!LQ_IsEmpty(Queue))
    {
        Node* Popped = LQ_Dequeue(Queue);
        LQ_DestroyNode(Popped);
    }

    /*  ť�� ���� ����ҿ��� ���� */
    free(Queue);
}

Node* LQ_CreateNode(char* NewData, int priority)
{
    Node* NewNode = (Node*)malloc(sizeof(Node));
    NewNode->Data = (char*)malloc(strlen(NewData) + 1);

    strcpy(NewNode->Data, NewData);  /*  �����͸� �����Ѵ�. */

    NewNode->NextNode = NULL; /*  ���� ��忡 ���� �����ʹ� NULL�� �ʱ�ȭ �Ѵ�. */
    NewNode->Priority = priority;
    return NewNode;/*  ����� �ּҸ� ��ȯ�Ѵ�. */
}

void  LQ_DestroyNode(Node* _Node)
{
    free(_Node->Data);
    free(_Node);
}

void LQ_Enqueue(LinkedQueue* Queue, Node* NewNode)
{
    if (Queue->Front == NULL)
    {
        Queue->Front = NewNode;
        Queue->Rear = NewNode;
        Queue->Count++;
    }
    else
    {
        Queue->Rear->NextNode = NewNode;
        Queue->Rear = NewNode;
        Queue->Count++;
    }
}

Node* LQ_Dequeue(LinkedQueue* Queue)
{
    /*  LQ_Dequeue() �Լ��� ��ȯ�� �ֻ��� ��� */
    Node* Front = Queue->Front;

    if (Queue->Front->NextNode == NULL)
    {
        Queue->Front = NULL;
        Queue->Rear = NULL;
    }
    else
    {
        Queue->Front = Queue->Front->NextNode;
    }

    Queue->Count--;

    return Front;
}

int LQ_IsEmpty(LinkedQueue* Queue)
{
    return (Queue->Front == NULL);
}