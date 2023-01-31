#include <stdio.h>
#include "Score.h"
#include <time.h>

void Swap(Score* A, Score* B)
{
    Score Temp = *A;
    *A = *B;
    *B = Temp;
}
//score 배열 형태로 바꿔준다 ( score 배열을 전달할거임)
int Partition(Score DataSet[], int Left, int Right)
{
    int First = Left;
    //기준값을 받을 때 배열의 첫번째를 피봇으로 잡을거고 그 안에있는 score 값을 기준으로 잡을거다.
    //따라서 피봇도 score 구조체 타입으로 받아준다.
    Score Pivot = DataSet[First];

    ++Left;

    while (Left <= Right)
    {
        //기준점과 데이터의 스코어를 비교할것임
        while (DataSet[Left].score <= Pivot.score && Left < Right)
            ++Left;

        while (DataSet[Right].score >= Pivot.score && Left <= Right)
            --Right;
        //스코어 배열의 원소 전체를 바꿀것임
        if (Left < Right)
            Swap(&DataSet[Left], &DataSet[Right]);
        else
            break;
    }

    Swap(&DataSet[First], &DataSet[Right]);

    return Right;
}

void QuickSort(Score DataSet[], int Left, int Right)
{
    if (Left < Right)
    {
        int Index = Partition(DataSet, Left, Right);

        QuickSort(DataSet, Left, Index - 1);
        QuickSort(DataSet, Index + 1, Right);
    }
}

int main(void)
{
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];

    clock_t startTime = 0;
    clock_t endTime = 0;
    startTime = clock();
    QuickSort(DataSet, 0, Length - 1);
    endTime = clock();
    for (int i = 0; i < 10; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }

    for (int i = 29990; i < 30000; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }

    float resultTime = (float)(endTime - startTime) / CLOCKS_PER_SEC;
    printf("3만개의 퀵 정렬 시간 : %lf sec ", resultTime);

    return 0;
}
