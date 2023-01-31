#include <stdio.h> 
#include <string.h> 
#include "Score.h"

void InsertionSort(Score DataSet[], int Length)
{
    //score타입 배열로 바꿔준다
    Score value;
    //초기화
    value.number = 0;
    value.score = 0.0f;

    for (int i = 1; i < Length; i++)
    {
        if (DataSet[i - 1].score <= DataSet[i].score)
            continue;

        //뒤의 작은값이 들어옴
        value = DataSet[i];

        for (int j = 0; j < i; j++)
        {
            //값만 비교해서
            if (DataSet[j].score > value.score)
            {
                //구조체 전체를 바꿔준다
                memmove(&DataSet[j + 1], &DataSet[j], sizeof(DataSet[0]) * (i - j));
                DataSet[j] = value;
                break;
            }
        }
    }
}

int main(void)
{
    //구조체타입 배열을 쓸거라서 이거 주석처리함
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];

    InsertionSort(DataSet, Length);
    //0부터 10까지
    for (int i = 0; i < 10; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    //29990부터 30000까지
    for (int i = 29990; i < Length; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }


    return 0;
}
