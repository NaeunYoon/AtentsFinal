#include <stdio.h>

int main() 
{
	int DataSet[] = { 4,7,8,10,5,3,1,2,6,9 };
	int length = sizeof(DataSet) / sizeof(int);
	int tmp = 0;
	//버블소트를 구혐

	//정렬된 내용을 출력

	for (int i = 0; i < length; i++)
	{
		for (int j = i+1; j < length; j++)
		{
			if (DataSet[i] > DataSet[j])
			{
				tmp = DataSet[i];
				//printf("%d", tmp);
				DataSet[i] = DataSet[j];
				//printf("%d", DataSet[i]);
				DataSet[j] = tmp;
			}

		}
		printf("%d, ", DataSet[i]);
	}

	return 0;

}