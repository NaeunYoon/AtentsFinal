#include "CircularQueue.h"

void CQ_CreateQueue(CircularQueue** Queue, int Capacity)
{
	/* 큐를 자유 저장소에 생성 */
	(*Queue) = (CircularQueue*)malloc(sizeof(CircularQueue));

	/* 입력된 Capacity + 1 만큼의 노드를 자유 저장소에 생성 */
	(*Queue)->Nodes = (Node*)malloc(sizeof(Node) * (Capacity + 1));

}


void CQ_DestroyQueue(CircularQueue* Queue);
void CQ_Enqueue(CircularQueue* Queue, ElementType Data);
ElementType CQ_Dequeue(CircularQueue* Queue);
int CQ_GetSize(CircularQueue* Queue);
int CQ_IsEmpty(CircularQueue* Queue);
int CQ_IsFull(CircularQueue* Queue);