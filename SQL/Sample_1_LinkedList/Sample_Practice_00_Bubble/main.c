#include <stdio.h>

int main() 
{
	int DataSet[] = { 4,7,8,10,5,3,1,2,6,9 };
	int Length = sizeof(DataSet) / sizeof(int);

	//�����Ʈ ����
	for (int i = 0; i < Length -1 ; i++)
	{
		//Length-1 ���ִ� ���� : Length ��ŭ ������ i+1���� ���ư��� ����
		//for ���� �ѹ� ������ �ѹ��� �����ϱ� ������ ū ���� ���� �ڷ� ����
		//���� ������ ���� �� �񱳸� ����� �ϱ� ������ for ������ �� �� ������
			
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

	//���� ���� ���
	for (int i = 0; i < Length; i++)
	{
		printf("%d ", DataSet[i]);
	}
	
	return 0;
}