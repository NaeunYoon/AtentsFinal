#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include "Calculator.h"

int main(void) 
{
	char InfixExpression[100];	//������ ���� ���� �迭
	char PostfixExpression[100];	//������ ���� ���� �迭

	double Result = 0.0;

	memset(InfixExpression, 0, sizeof(InfixExpression));
	memset(PostfixExpression, 0, sizeof(PostfixExpression));

	printf("Enter Infix Expression : ");
	scanf("%s", InfixExpression);

	GetPostfix(InfixExpression, PostfixExpression);

	printf("Infix : %s \n Postfix :\n", InfixExpression, PostfixExpression);

	Result = Calculate(PostfixExpression);

	printf("Calculation Result : %f\n", Result);

	return 0;




}