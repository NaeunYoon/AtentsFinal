#include <stdio.h> 
#include <string.h> 
#include "Score.h"

void InsertionSort(Score DataSet[], int Length)
{
    //scoreŸ�� �迭�� �ٲ��ش�
    Score value;
    //�ʱ�ȭ
    value.number = 0;
    value.score = 0.0f;

    for (int i = 1; i < Length; i++)
    {
        if (DataSet[i - 1].score <= DataSet[i].score)
            continue;

        //���� �������� ����
        value = DataSet[i];

        for (int j = 0; j < i; j++)
        {
            //���� ���ؼ�
            if (DataSet[j].score > value.score)
            {
                //����ü ��ü�� �ٲ��ش�
                memmove(&DataSet[j + 1], &DataSet[j], sizeof(DataSet[0]) * (i - j));
                DataSet[j] = value;
                break;
            }
        }
    }
}

int main(void)
{
    //����üŸ�� �迭�� ���Ŷ� �̰� �ּ�ó����
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];

    InsertionSort(DataSet, Length);
    //0���� 10����
    for (int i = 0; i < 10; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    //29990���� 30000����
    for (int i = 29990; i < Length; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }


    return 0;
}
