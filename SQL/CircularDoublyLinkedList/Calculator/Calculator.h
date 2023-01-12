#ifndef CALCULATOR_H
#define CALCULATOR_H

#include <stdlib.h>


typedef enum
{
	LEFT_PARENTHESIS = '(',
	RIGHT_PARENTHESIS = ')',
	PLUE = '+',
	MINUS = '-',
	MULTIPLY = '*',
	DIVIDE = '/',
	SPACE = ' ',
	OPERAND
}SYMBOL;

int IsNumber(char Cipher);
unsigned int GetNextToken(char* Expression, char* Token, int* TYPE);
int IsPrior(char Operator1, char Operator2);
void GetPostfix(char* InnfixExpression, char* PostfixExpression);
double Calculate(char* PostfixExpression);

#endif // !CALCULATOR_H
