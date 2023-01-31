#include <stdio.h> 
#include "Score.h"
/*
Score.h 는 구조체 형식이다.
int number와 double score로 구성되어 있다
구조체형 배열은 Dataset[] 이다.
즉 Dataset[0] 안에는 int double 이 각각 들어있다.
*/


void BubbleSort(Score DataSet[], int Length)
{
    // int 값 대신 스코어형 구조체를 tmp로 선언해준다
    Score temp;
    //temp 초기화를 해준다
    temp.number = 0;
    temp.score = 0.0f;

    for (int i = 0; i < Length - 1; i++)
    {
        for (int j = 0; j < Length - (i + 1); j++)
        {
            //이 안에 있는 값만 비교해서 구조체 자체를 바꿔야 한다. (그렇지 않으면 number 가 제대로 나오지 않음)
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
    //int형 Dataset이 아니라 헤더파일에 있는 구조체형 배열을 쓸 것이기 때문에 주석처리를 함
    //int DataSet[] = { 6, 4, 2, 3, 1, 5 };
    
    //배열의 길이를 함수에 넘기기 위해서 길이를 구해준다
    int Length = sizeof DataSet / sizeof DataSet[0];

    //구조체형 배열 Dataset과 길이가 들어감
    BubbleSort(DataSet, Length);

    //전부 다 출력하면 오래걸리기 때문에 앞에 10개 출력 (구조체 안 배열의 공간은 . 을 사용해서 접근한다)
    for (int i = 0; i < 10; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    //뒤에 10개 출력한다 (구조체 안 배열의 공간은 . 을 사용해서 접근한다)
    for (int i = 29990; i < Length; i++)
    {
        printf("number : %d, score : %lf ", DataSet[i].number, DataSet[i].score);
        printf("\n");
    }
    printf("\n");

    return 0;
}
