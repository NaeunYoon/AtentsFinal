#include <stdio.h> 
#include <string.h> 
#include "Score.h"
#include <time.h>

//score 데이터 타입이기 때문에 score 배열로 바꿔야 한다
void InsertionSort(Score DataSet[], int Length)
{

    Score value;
    value.number = 0;
    value.score = 0.0f;

    for (int i = 1; i < Length; i++)
    {
        if (DataSet[i - 1].score <= DataSet[i].score)
            continue;

        value = DataSet[i];

        for (int j = 0; j < i; j++)
        {
            if (DataSet[j].score > value.score)
            {   //어차피 score 배열이기 때문에 굳이 sizeof 를 score로 하지 않아도 됨
                memmove(&DataSet[j + 1], &DataSet[j], sizeof(DataSet[0]) * (i - j));
                DataSet[j] = value;
                break;
            }
        }
    }
}

int main(void)
{
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];

    clock_t startTime = 0;
    clock_t endTime = 0;
    startTime = clock();
    InsertionSort(DataSet, Length);
    endTime = clock();
    for (int i = 0; i < 10; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    for (int i = 29990; i < Length; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    //형변환 필수
    float resultTime = (float)(endTime - startTime) / CLOCKS_PER_SEC;
    printf("3만개의 데이터 삽입 정렬 시간 : %lf sec", resultTime);

    return 0;
}
