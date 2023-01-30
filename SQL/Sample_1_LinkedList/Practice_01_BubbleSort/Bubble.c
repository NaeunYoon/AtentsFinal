#include "Score.h"
#include <stdio.h> 

void BubbleSort(Score DataSet[], int Length)
{
    Score temp;
    temp.number = 0;
    temp.score = 0.0;

    for (int i = 0; i < Length - 1; i++)
    {
        for (int j = 0; j < Length - (i + 1); j++)
        {
            if (DataSet[j].score > DataSet[j + 1].score)
            {
                temp = DataSet[j + 1];
                DataSet[j + 1] = DataSet[j];
                DataSet[j] = temp;
            }
        }
    }
}

int main(void)
{
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];
    //Score Dataset;
    BubbleSort(DataSet, Length);

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


    return 0;
}