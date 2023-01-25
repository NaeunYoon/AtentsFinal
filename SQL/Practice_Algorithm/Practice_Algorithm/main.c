#include <stdio.h>

void BubbleSort(int DataSet[],int Length)
{
	int i = 0;
	int j = 0;
	int tmp = 0;

	for ( i = 0; i < Length-1; i++)
	{
		for ( j = 0; j < Length-(i+1); j++)
		{
			if (DataSet[j] > DataSet[j + 1]) {
				tmp = DataSet[j + 1];
				DataSet[j + 1] = DataSet[j];
				DataSet[j] = tmp;
			}
		}
	}
}


int main() 
{
	//int DataSet[] = { 4,7,8,10,5,3,1,2,6,9 };
	//int length = sizeof(DataSet) / sizeof(int);
	//int tmp = 0;
	////버블소트를 구혐

	////정렬된 내용을 출력

	//for (int i = 0; i < length; i++)
	//{
	//	for (int j = i+1; j < length; j++)
	//	{
	//		if (DataSet[i] > DataSet[j])
	//		{
	//			tmp = DataSet[i];
	//			//printf("%d", tmp);
	//			DataSet[i] = DataSet[j];
	//			//printf("%d", DataSet[i]);
	//			DataSet[j] = tmp;
	//		}

	//	}
	//	printf("%d, ", DataSet[i]);
	//}

	int DataSet[] = { 6,4,2,3,1,5 };
	int Length = sizeof DataSet / sizeof DataSet[0];
	int i = 0;
	BubbleSort(DataSet, Length);
	for ( i = 0; i < Length; i++)
	{
		printf("%d", DataSet[i]);
	}
	printf("\n");



	return 0;

}