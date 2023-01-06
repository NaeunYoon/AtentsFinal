#pragma once
#include "LinkedList.h"

/*  노드 생성 */
Node* SLL_CreateNode(ElementType NewData) 
{

	Node* NewNode = (Node*)malloc(sizeof(Node));

	if (NewNode != NULL) {
		/*  데이터를 저장한다. */
		NewNode->Data = NewData;	//데이터를 저장한다(0,1,2,3,4)
		/*  다음 노드에 대한 포인터는 NULL로 초기화 한다. */
		NewNode->NextNode = NULL;	
		//주소값에 저장된 것이 없을 때에는 null이라고 한다
		//주소값이 저장된 공간의 0은 null이다
	}
	/*  노드의 주소를 반환한다. */
	return NewNode;	
}
/*  노드 소멸 */
void SLL_DestroyNode(Node* Node) 
{
	free(Node);
}
/*  노드 추가 */
void SLL_AppendNode(Node** Head, Node* NewNode) 
{	//리스트의 주소값을 받기 때문에 node**
	/*  헤드 노드가 NULL이라면 새로운 노드가 Head */
	//*Head : 메인에 있는 리스트 변수의 주소값의 포인터 연산자(*&List) -> 메인에 있는 리스트 변수
	//메인에 있는 리스트 변수의 값이 null이냐고 물음 ( 리스트 변수는 왜 만들었냐? -> 헤드노드의 주소값을 저장하려고)
	//메인에 있는 리스트 주소에 연결된게 아무도 없니? 라고 물음 => 붙어있는 노드가 아무것도 없으므로
	//새롭게 만들어진 주소값을 넣어준다
	if ((*Head) == NULL) {	//메인에 있는 리스트 변수가 0이니?
		*Head = NewNode;	//헤드노드를 할당함 ( 맨 처음 만들어진 0의 값이 있는 노드가 헤드 노드가 된다)
	}
	/*  테일을 찾아 NewNode를 연결한다. */
	else 
	{	//테일을 찾아 newNode를 연결한다
		Node* Tail = (*Head);
		while (Tail->NextNode !=NULL)
		{
			Tail = Tail->NextNode;
		}
		Tail->NextNode = NewNode;
	}
}
/*  노드 삽입 */
void SLL_InsertAfter(Node* Current, Node* NewNode) {

	NewNode->NextNode = Current->NextNode;
	Current->NextNode = NewNode;
}

void SLL_InsertNewHead(Node** Head, Node* NewHead) {
	if (*Head == NULL) 
	{
		(*Head) = NewHead;
	}
	else
	{
		NewHead->NextNode = (*Head);
		(*Head) = NewHead;
	}
}
/*  노드 제거 */
void SLL_RemoveNode(Node** Head, Node* Remove) {
	if (*Head == Remove) 
	{
		*Head = Remove->NextNode;
	}
	else 
	{
		Node* Current = *Head;
		while (Current != NULL && Current->NextNode != Remove) 
		{
			Current = Current->NextNode;
		}
		if (Current != NULL) {
			Current->NextNode = Remove->NextNode;
		}
		
	}
}
/*  노드 탐색 */
Node* SLL_GetNodeAt(Node* Head, int Location) 
{
	Node* Current = Head;

	while (Current !=NULL&&(--Location)>=0)
	{
		Current = Current->NextNode;
	}
	return Current;
}
/*  노드 수 세기 */
int SLL_GetNodeCount(Node* Head) 
{
	int Count = 0;
	Node* Current = Head;
	while (Current != NULL)
	{
		Current = Current->NextNode;
		Count++;
	}
	return Count;
}