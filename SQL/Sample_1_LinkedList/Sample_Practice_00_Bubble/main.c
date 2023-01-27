#include <stdio.h>

int main() 
{
	int DataSet[] = { 4,7,8,10,5,3,1,2,6,9 };
	int Length = sizeof(DataSet) / sizeof(int);

	//버블소트 구현
	for (int i = 0; i < Length -1 ; i++)
	{
		//Length-1 해주는 이유 : Length 만큼 돌리면 i+1번이 돌아가지 않음
		//for 문을 한번 돌리면 한번만 정렬하기 때문에 큰 수가 가장 뒤로 간다
		//따라서 각각의 원소 값 비교를 해줘야 하기 때문에 for 루프를 두 번 돌린다
			
		for (int j = i+1; j < Length; j++)
		{
			if (DataSet[i] > DataSet[j]) 
			{
				int temp = DataSet[j];
				DataSet[j] = DataSet[i];
				DataSet[i] = temp;
			}
		}
	}

	//정렬 내용 출력
	for (int i = 0; i < Length; i++)
	{
		printf("%d ", DataSet[i]);
	}
	
	return 0;
}