#include<stdio.h>

int global = 20;	//�ܺκ���, ��������
int SetScore(int value) 
{
	static int score = 0; //�������� : �������� �ʴ´� ( �Լ� ���� ������ �Ⱦ�����)
							//�Լ��� �ѹ� ��������� �����ǰ� ������� �ʴ´�
	global = 100;
	score += value;
	return score;
}

int main() {

	int a;
	a = 20;
	{
		int a = 100;	//�ڵ����� ( �߰�ȣ ������ �����)
	}

	for (int i = 0; i < 100; i++)
	{
		SetScore(i);
	}
	int ret = SetScore(0);
	printf("ret = %d", ret);
	//===========================================================
	int* pa =(int*)malloc(100);	//�����޸� ���� �Ҵ�

	 for (int i = 0; i < 25; i++)
	 {
		 pa[i] = i;
	 }

	 for (int i = 0; i < 25; i++)
	 {
		 printf("pa[%d] = %d\n", i, pa[i]);
	 }

	 free(pa);	//�����޸� ���� ��ȯó��

	return 0;

	//malloc calloc realloc �� ����ؼ� �޸� �Ҵ�
	//free �� ���� ��ȯ�Ѵ�
	//�ݵ�� �����޸� ������ ��ȯ�� ����� �Ѵ�.
}