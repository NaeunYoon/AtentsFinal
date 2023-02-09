#define _CRT_SECURE_NO_WARNINGS
#include "LinekedQueue.h"

void  LQ_CreateQueue(LinkedQueue** Queue)
{
    /*  큐를 자유저장소에 생성 */
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

    /*  큐를 자유 저장소에서 해제 */
    free(Queue);
}

Node* LQ_CreateNode(char* NewData, int priority)
{
    Node* NewNode = (Node*)malloc(sizeof(Node));
    NewNode->Data = (char*)malloc(strlen(NewData) + 1);

    strcpy(NewNode->Data, NewData);  /*  데이터를 저장한다. */

    NewNode->NextNode = NULL; /*  다음 노드에 대한 포인터는 NULL로 초기화 한다. */
    NewNode->Priority = priority;
    return NewNode;/*  노드의 주소를 반환한다. */
}

void  LQ_DestroyNode(Node* _Node)
{
    free(_Node->Data);
    free(_Node);
}

void LQ_Enqueue(LinkedQueue* Queue, Node* NewNode)
{
    if (Queue->Front == NULL)   //노드가 없으면?
    {
        Queue->Front = NewNode;
        Queue->Rear = NewNode;
        Queue->Count++;
    }
    else
    {
        //헤드노드의 주소값을 저장
        Node* Current = Queue->Front;
        //Current의 앞쪽 노드의 주소값을 저장
        Node* Prev = NULL;

        while (Current != NULL) //current가 꼬리노드 다음 노드가 아닐 때까지
        {
            if (Current->Priority < NewNode->Priority)
            {
                if (Current == Queue->Front)
                {
                    //current가 헤드인 경우 ( 또는 prev == null : current 가 head이다라는 뜻)
                    if (Prev == NULL)
                    {
                        NewNode->NextNode = Current;
                        Queue->Front = NewNode;
                        Queue->Count++;
                        break;
                    }
                    else 
                    {
                        //헤드노드가 아닌 경우
                        NewNode->NextNode = Prev->NextNode;
                        Prev->NextNode = NewNode;
                        Queue->Count++;
                        break;
                    }
                }
                else if (Current->NextNode == NULL)
                {
                    //뉴노드가 꼬리노드보다 우선순위가 낮다
                    //꼬리노드 뒤에 뉴 노드가 추가되어야 한다
                    Current->NextNode = NewNode;
                    //꼬리노드를 뉴노드로 변경
                    Queue->Rear = NewNode;
                    Queue->Count++;
                    break;
                }
            }
            Prev = Current;
            Current = Current->NextNode;
        }


        Queue->Rear->NextNode = NewNode;
        Queue->Rear = NewNode;
        Queue->Count++;
    }
}

Node* LQ_Dequeue(LinkedQueue* Queue)
{
    /*  LQ_Dequeue() 함수가 반환할 최상위 노드 */
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