#include "LinkedList.h"
//#include <stdio.h>

int main(void) 
{
	int i = 0;
	int Count = 0;
	Node* List = NULL;	//헤드 노드 주소값 저장용
	Node* Current = NULL;	//현재 노드의 주소값
	Node* NewNode = NULL;	//새롭게 만든 노드의 주소값
	/*  노드 5개 추가 */
	for (int i = 0; i < 5; i++)	//0,1,2,3,4
	{
		NewNode = SLL_CreateNode(i);
		SLL_AppendNode(&List, NewNode);//head : main의 주소값, new : 새롭게 만들어진 노드의 주소값 (2000)
	}

	NewNode = SLL_CreateNode(-1);
	SLL_InsertNewHead(&List, NewNode);

	NewNode = SLL_CreateNode(-2);
	SLL_InsertNewHead(&List, NewNode);
	/*  리스트 출력 */
	Count = SLL_GetNodeCount(List);
	for (int i = 0; i < Count; i++)
	{
		Current = SLL_GetNodeAt(List, i);
		printf("List[%d] : %d\n", i, Current->Data);
	}
	/*  리스트의 세번째 노드 뒤에 새 노드 삽입 */
	printf("\nInserting 3000 After [2]...\n\n");

	Current = SLL_GetNodeAt(List, 2);
	NewNode = SLL_CreateNode(3000);

	SLL_InsertAfter(Current, NewNode);
	/*  리스트 출력 */
	Count = SLL_GetNodeCount(List);
	for (int i = 0; i < Count; i++)
	{
		Current = SLL_GetNodeAt(List, i);
		printf("List [%d] : %d\n", i, Current->Data);
	}
	/*  모든 노드를 메모리에서 제거     */
	printf("\nDestroying List...\n");
	for (int i = 0; i < Count; i++)
	{
		Current = SLL_GetNodeAt(List, 0);
		if (Current != NULL) {
			SLL_RemoveNode(&List, Current);
			SLL_DestroyNode(Current);
		}
	}
	return 0;
}