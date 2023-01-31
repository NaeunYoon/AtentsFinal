#include <stdio.h>
#include "Score.h"
#include <time.h>

void Swap(Score* A, Score* B)
{
    Score Temp = *A;
    *A = *B;
    *B = Temp;
}
//score �迭 ���·� �ٲ��ش� ( score �迭�� �����Ұ���)
int Partition(Score DataSet[], int Left, int Right)
{
    int First = Left;
    //���ذ��� ���� �� �迭�� ù��°�� �Ǻ����� �����Ű� �� �ȿ��ִ� score ���� �������� �����Ŵ�.
    //���� �Ǻ��� score ����ü Ÿ������ �޾��ش�.
    Score Pivot = DataSet[First];

    ++Left;

    while (Left <= Right)
    {
        //�������� �������� ���ھ ���Ұ���
        while (DataSet[Left].score <= Pivot.score && Left < Right)
            ++Left;

        while (DataSet[Right].score >= Pivot.score && Left <= Right)
            --Right;
        //���ھ� �迭�� ���� ��ü�� �ٲܰ���
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
    printf("3������ �� ���� �ð� : %lf sec ", resultTime);

    return 0;
}
