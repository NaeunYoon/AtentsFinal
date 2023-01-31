#include <stdlib.h> 
#include <stdio.h> 
#include <string.h>
#include "Score.h"
#include <time.h>

/*  리턴값이
    < 0 이면, _elem1이 _elem2보다 작다.
    0   이면, _elem1이 _elem2와 같다.
    > 0 이면, _elem1이 _elem2보다 크다.  */

//score 타입의 주소값이 들어온다.
int CompareScore(const void* _elem1, const void* _elem2)
{
    //elem으로 각각의 score 배열의 주소값이 들어온다

    //void 타입으로 들어왔으니 score 주소값으로 형변환을 명시적으로 해준다.
    Score* elem1 = (Score*)_elem1;
    Score* elem2 = (Score*)_elem2;

    //주소값으로 전달할떄는 우린 -> 를 하기로 했다
    if (elem1->score > elem2->score)
        return 1;
    //또는 이렇게 쓸 수 있음
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

    printf("3만개의 퀵2 정렬 시간 : %lf sec", resultTime);


    return 0;
}
