#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

//����ü�� ������ Ÿ���� ����
struct Student
{
	char name[30];	//����ü ���
	int age;
	int gender;
	char phoneNum[20];
};

int main() {
	//�л� ���� ���α׷�

	char name[30];
	int age;
	int gender;
	char phoneNum[12];

	//�л��� 1���ΰ���?
	//100���̶�� ����
	//100���� �л��� ����� ���� ������� 100��
	//���� ������ �ִ� �����͸� �ϳ��� ���̼� ���ο� ������ Ÿ���� ���� �� �ִ� => ����ü
	struct Student a;	//����ü ���� ����� ������ �� . (period ������)�� ���
	a.age = 10;

	//����ü ������ �ּҰ����� ������ ��? -> (ȭ��ǥ ������)�� ���
	(&a)->age=10;
	struct Student array[100];
	//�� ����� ������ Ÿ���� Student ����ü��, �� �� ĭ���� ����ü�� ���� �� �ִ�
	//�� ĭ�� 4���� �������� �������� �ִ�
	int length = sizeof(array) / sizeof(array[0]);
	for (int i = 0; i < length; i++)
	{
		sprintf(array[i].name,"monster+%d",i);
		array[i].age = i % 5 + 10;
		array[i].gender = i % 2;
		sprintf(array[i].phoneNum,"010-0000-0000",i);
	}
	for (int i = 0; i < length; i++)
	{
		print("�̸�",array[i].name);
		print("����",array[i].age);
		print("����",array[i].gender);
		print("��ȣ", array[i].phoneNum);
	}


	return 0;
}