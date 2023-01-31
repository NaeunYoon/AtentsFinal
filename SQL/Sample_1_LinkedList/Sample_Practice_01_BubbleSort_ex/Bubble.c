#include <stdio.h> 
#include "Score.h"
/*
Score.h �� ����ü �����̴�.
int number�� double score�� �����Ǿ� �ִ�
����ü�� �迭�� Dataset[] �̴�.
�� Dataset[0] �ȿ��� int double �� ���� ����ִ�.
*/


void BubbleSort(Score DataSet[], int Length)
{
    // int �� ��� ���ھ��� ����ü�� tmp�� �������ش�
    Score temp;
    //temp �ʱ�ȭ�� ���ش�
    temp.number = 0;
    temp.score = 0.0f;

    for (int i = 0; i < Length - 1; i++)
    {
        for (int j = 0; j < Length - (i + 1); j++)
        {
            //�� �ȿ� �ִ� ���� ���ؼ� ����ü ��ü�� �ٲ�� �Ѵ�. (�׷��� ������ number �� ����� ������ ����)
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
    //int�� Dataset�� �ƴ϶� ������Ͽ� �ִ� ����ü�� �迭�� �� ���̱� ������ �ּ�ó���� ��
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    
    //�迭�� ���̸� �Լ��� �ѱ�� ���ؼ� ���̸� �����ش�
    int Length = sizeof DataSet / sizeof DataSet[0];

    //����ü�� �迭 Dataset�� ���̰� ��
    BubbleSort(DataSet, Length);

    //���� �� ����ϸ� �����ɸ��� ������ �տ� 10�� ��� (����ü �� �迭�� ������ . �� ����ؼ� �����Ѵ�)
    for (int i = 0; i < 10; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    //�ڿ� 10�� ����Ѵ� (����ü �� �迭�� ������ . �� ����ؼ� �����Ѵ�)
    for (int i = 29990; i < Length; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    printf("\n");

    return 0;
}
