#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>

int main(int args, char** argv)
{
	char* FilePath = NULL;
	char* Pattern;

	FilePath = argv[1];
	Pattern = argv[2];
	FILE* fp;
	fp = fopen(FilePath, "r");

	if (fp == NULL)
	{
		printf("파일 열기에 실패하였습니다");
		return;
	}
	int i = 0;
	char buff[512];
	while (fgets(buff,512,fp)!=NULL)
	{
		if (Pattern != buff[i])
		{
			i++;
		}
		else if(Pattern == buff[i])
		{
			printf("%s\n", buff[i]);
		}
	}
	fclose(fp);

	return 0;

}