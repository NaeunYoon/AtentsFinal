#include "LinekedQueue.h"
int main(void)
{
    Node* Popped;
    LinkedQueue* Queue;

    LQ_CreateQueue(&Queue);

    //LQ_Enqueue(Queue, LQ_CreateNode("abc"));
    //LQ_Enqueue(Queue, LQ_CreateNode("def"));
    //LQ_Enqueue(Queue, LQ_CreateNode("efg"));
    //LQ_Enqueue(Queue, LQ_CreateNode("hij"));

    printf("Queue Size : %d\n", Queue->Count);

    char data[100];
    int Priority = 0;
    while (1)
    {
        printf("ť�� ������ �����͸� �Է��ϼ���");
        scanf("%d,$s", &Priority, data);

        if (Priority <= -1)
        {
            break;
        }

        LQ_Enqueue(Queue, LQ_CreateNode(data, Priority));
        printf("ť ���");

        Node* Current = Queue->Front;

        while (Current !=NULL)
        {

        }
    }


    while (LQ_IsEmpty(Queue) == 0)
    {
        Popped = LQ_Dequeue(Queue);

        printf("Dequeue: %s \n", Popped->Data);

        LQ_DestroyNode(Popped);
    }

    LQ_DestroyQueue(Queue);

    return 0;
}