#include "Score.h"
#include <stdio.h> 
#include  <time.h>
void BubbleSort(Score DataSet[], int Length)
{
    //int �� �ƴ� score�� �ؾ��Ѵ�
    Score temp;
    //int ��
    temp.number = 0;
    //double ��
    temp.score = 0.0;

    for (int i = 0; i < Length - 1; i++)
    {
        for (int j = 0; j < Length - (i + 1); j++)
        {
            // �����͸� score ������ �񱳸� �Ѵ�
            if (DataSet[j].score > DataSet[j + 1].score)
            {
                temp = DataSet[j + 1];
                DataSet[j + 1] = DataSet[j];
                DataSet[j] = temp;
            }
        }
    }
}
/*
 �츮�� �ٷ���� �ϴ� �����ʹ� score Ÿ���̴�
 score score score...30000���� score�� �ְ�
 score �ȿ� number �� score ����� �ִ�
 �� score �� �������� sorting�� �ϴ°����� ����ü ��ü�� �ٲ���Ѵ�. (������ �پ�ٴϱ� ������ ��°�� �ٲ۴�)

*/
int main(void)
{
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];
    //Score Dataset;

    //���� �ð� ����
    //long�� clock_t ���� ��� ������ Ÿ���� �̿��Ѵ�
    clock_t  startTime = 0;
    clock_t  endTime = 0;
    //���� �ð�
    float resultTime = 0.0f;
    //���� ���� �ð��� ���
    startTime = clock(); //���۽ð��� �����´� (1/1000)
    //�����Ʈ ȣ�� (score ������ Ÿ���� ����)-> ���� score �迭�� �޾ƾ� �Ѵ�.(������ ���ھ� �迭�� ��)
    BubbleSort(DataSet, Length);
    //���� ���� �ð��� ���
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
    //���� �ð����� ���� �ð��� ���� 1000���� ����� �� ������ �ð��� �ٲ۴� (�������� �ð��� �ƴ� : ��ǻ�� ���ɿ� ���� �ٸ���)
    resultTime = (float)(endTime - startTime) / CLOCKS_PER_SEC;
    printf("3������ ������ ���� ���� �ð� : %lf sec", resultTime);

    return 0;
}