#include "Score.h"
#include <stdio.h> 
#include  <time.h>
void BubbleSort(Score DataSet[], int Length)
{
    //int 가 아닌 score로 해야한다
    Score temp;
    //int 형
    temp.number = 0;
    //double 형
    temp.score = 0.0;

    for (int i = 0; i < Length - 1; i++)
    {
        for (int j = 0; j < Length - (i + 1); j++)
        {
            // 데이터를 score 값으로 비교를 한다
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
 우리가 다루려고 하는 데이터는 score 타입이다
 score score score...30000개의 score가 있고
 score 안에 number 와 score 멤버가 있다
 이 score 를 기준으로 sorting을 하는거지만 구조체 전체를 바꿔야한다. (쌍으로 붙어다니기 때문에 통째로 바꾼다)

*/
int main(void)
{
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    int Length = sizeof DataSet / sizeof DataSet[0];
    //Score Dataset;

    //소팅 시간 계산용
    //long형 clock_t 정수 담는 데이터 타입을 이용한다
    clock_t  startTime = 0;
    clock_t  endTime = 0;
    //정렬 시간
    float resultTime = 0.0f;
    //소팅 전의 시간을 기록
    startTime = clock(); //시작시간을 가져온다 (1/1000)
    //버블소트 호출 (score 데이터 타입이 들어간다)-> 따라서 score 배열로 받아야 한다.(전달이 스코어 배열이 들어감)
    BubbleSort(DataSet, Length);
    //소팅 후의 시간을 기록
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
    //끝난 시간에서 시작 시간을 빼고 1000으로 나누어서 초 단위로 시간을 바꾼다 (절대적인 시간은 아님 : 컴퓨터 성능에 따라 다르다)
    resultTime = (float)(endTime - startTime) / CLOCKS_PER_SEC;
    printf("3만개의 데이터 버블 정렬 시간 : %lf sec", resultTime);

    return 0;
}