#define _CRT_SECURE_NO_WARNINGS
#include "LinekedQueue.h"
int main(void)
{
    Node* Popped;
    LinkedQueue* Queue;

    LQ_CreateQueue(&Queue);

   

    char data[100]; //���ڿ� �Է¿�
    int Priority = 0;   //�켱������ �Է¿�
    while (1)
    {
        //ť �����͸� �Է¹޴´�
        printf("ť�� ������ �����͸� �Է��ϼ��� : Priority data / exit : -1 ");
        scanf("%d, %s", &Priority, data);

        if (Priority <= -1)
        {
            break;
        }

        //��带 ���� ť�� �������
        LQ_Enqueue(Queue, LQ_CreateNode(data, Priority));
        //ť ���
        printf("ť ���");

        Node* Current = Queue->Front;

        while (Current != NULL)
        {
            printf("Priority : %d, Data : %s \n", Current->Priority, Current->Data);

            Current = Current->NextNode;
        }
    }

    //ť�� �ִ� ������ ����
    while (LQ_IsEmpty(Queue) == 0)
    {
        Popped = LQ_Dequeue(Queue);

        printf("Dequeue: %s \n", Popped->Data);

        LQ_DestroyNode(Popped);
    }

    LQ_DestroyQueue(Queue);

    return 0;
}