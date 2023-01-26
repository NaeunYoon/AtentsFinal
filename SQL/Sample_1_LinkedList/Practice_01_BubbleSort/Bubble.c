#include "Score.h"
#include <stdio.h> 

void BubbleSort(Score* DataSet[], int Length)
{
    Score temp;
    temp.number = 0;
    temp.score = 0;

    for (int i = 0; i < Length - 1; i++)
    {
        for (int j = 0; j < Length - (i + 1); j++)
        {
            if (DataSet[j]->score > DataSet[j + 1]->score)
            {
                temp.score = DataSet[j + 1]->score;
                DataSet[j + 1]->score = DataSet[j]->score;
                DataSet[j]->score = temp.score;
            }
        }
    }
}

int main(void)
{
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];
    Score Dataset;
    BubbleSort(DataSet, Length);

    for (int i = 0; i < Length; i++)
    {
        printf("%lf ", DataSet[i].score);
    }

    printf("\n");

    return 0;
}