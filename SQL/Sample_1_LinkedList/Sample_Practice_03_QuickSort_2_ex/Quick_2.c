#include <stdlib.h> 
#include <stdio.h> 
#include <string.h> 
#include "Score.h"

/*  리턴값이
    < 0 이면, _elem1이 _elem2보다 작다.
    0   이면, _elem1이 _elem2와 같다.
    > 0 이면, _elem1이 _elem2보다 크다.  */


int CompareScore(const void* _elem1, const void* _elem2)
{
    Score* elem1 = (Score*)_elem1;
    Score* elem2 = (Score*)_elem2;

    if (elem1->score > elem2->score)
        return 1;
    else if (elem1->score < elem2->score)
        return -1;
    else
        return 0;
}

int main(void)
{
    //구조체형 배열 사용할거라서 주석처리
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];

    qsort((void*)DataSet, Length, sizeof(Score), CompareScore);

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
