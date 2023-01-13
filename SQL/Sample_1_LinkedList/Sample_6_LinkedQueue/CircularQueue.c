#include "CircularQueue.h"

void CQ_CreateQueue(CircularQueue** Queue, int Capacity)
{
	/* ť�� ���� ����ҿ� ���� */
	(*Queue) = (CircularQueue*)malloc(sizeof(CircularQueue));

	/* �Էµ� Capacity + 1 ��ŭ�� ��带 ���� ����ҿ� ���� */
	(*Queue)->Nodes = (Node*)malloc(sizeof(Node) * (Capacity + 1));

}


void CQ_DestroyQueue(CircularQueue* Queue);
void CQ_Enqueue(CircularQueue* Queue, ElementType Data);
ElementType CQ_Dequeue(CircularQueue* Queue);
int CQ_GetSize(CircularQueue* Queue);
int CQ_IsEmpty(CircularQueue* Queue);
int CQ_IsFull(CircularQueue* Queue);