#include<iostream>
#include "CustomList.h"
using namespace std;



int main() {
	CustomList* pList = new CustomList();

	if (pList != nullptr) {
		delete pList;
	}

	

}