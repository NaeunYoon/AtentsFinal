#include <stdio.h> 
#include <string.h> 
#include "Score.h"
#include <time.h>

//score ������ Ÿ���̱� ������ score �迭�� �ٲ�� �Ѵ�
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
            {   //������ score �迭�̱� ������ ���� sizeof �� score�� ���� �ʾƵ� ��
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
    //����ȯ �ʼ�
    float resultTime = (float)(endTime - startTime) / CLOCKS_PER_SEC;
    printf("3������ ������ ���� ���� �ð� : %lf sec", resultTime);

    return 0;
}
