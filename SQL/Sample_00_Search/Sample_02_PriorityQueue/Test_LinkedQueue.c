#define _CRT_SECURE_NO_WARNINGS
#include "LinekedQueue.h"
int main(void)
{
    Node* Popped;
    LinkedQueue* Queue;

    LQ_CreateQueue(&Queue);

   

    char data[100]; //문자열 입력용
    int Priority = 0;   //우선순위값 입력용
    while (1)
    {
        //큐 데이터를 입력받는다
        printf("큐에 저장할 데이터를 입력하세요 : Priority data / exit : -1 ");
        scanf("%d, %s", &Priority, data);

        if (Priority <= -1)
        {
            break;
        }

        //노드를 만들어서 큐에 집어넣음
        LQ_Enqueue(Queue, LQ_CreateNode(data, Priority));
        //큐 출력
        printf("큐 출력");

        Node* Current = Queue->Front;

        while (Current != NULL)
        {
            printf("Priority : %d, Data : %s \n", Current->Priority, Current->Data);

            Current = Current->NextNode;
        }
    }

    //큐에 있는 데이터 삭제
    while (LQ_IsEmpty(Queue) == 0)
    {
        Popped = LQ_Dequeue(Queue);

        printf("Dequeue: %s \n", Popped->Data);

        LQ_DestroyNode(Popped);
    }

    LQ_DestroyQueue(Queue);

    return 0;
}