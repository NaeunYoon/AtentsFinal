#include <stdlib.h> 
#include <stdio.h> 
#include <string.h>
#include "Score.h"
#include <time.h>

/*  ���ϰ���
    < 0 �̸�, _elem1�� _elem2���� �۴�.
    0   �̸�, _elem1�� _elem2�� ����.
    > 0 �̸�, _elem1�� _elem2���� ũ��.  */

//score Ÿ���� �ּҰ��� ���´�.
int CompareScore(const void* _elem1, const void* _elem2)
{
    //elem���� ������ score �迭�� �ּҰ��� ���´�

    //void Ÿ������ �������� score �ּҰ����� ����ȯ�� ��������� ���ش�.
    Score* elem1 = (Score*)_elem1;
    Score* elem2 = (Score*)_elem2;

    //�ּҰ����� �����ҋ��� �츰 -> �� �ϱ�� �ߴ�
    if (elem1->score > elem2->score)
        return 1;
    //�Ǵ� �̷��� �� �� ����
    else if ((*elem1).score < (*elem2).score)
        return -1;
    else
        return 0;
}

int main(void)
{
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];
    int i = 0;

    clock_t startTime = 0;
    clock_t endTime = 0;
    startTime = clock();

    qsort((void*)DataSet, Length, sizeof(Score), CompareScore);
    endTime = clock();
    for (i = 0; i < 10; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    for (i = 29990; i < Length; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    float resultTime = (float)(endTime - startTime) / CLOCKS_PER_SEC;

    printf("3������ ��2 ���� �ð� : %lf sec", resultTime);


    return 0;
}
