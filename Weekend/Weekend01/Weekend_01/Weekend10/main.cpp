/*
������Ÿ���� �Ϲ�ȭ ���α׷���
���ø��̶�� ������� c++���� ����
�ڵ����� �Լ��� ������ش�

���ӽ����̽�
*/

#include <iostream>
using namespace std;



/*
���� ȸ�� �ȿ����� �������� ���ӽ����̽��� ������ �ִ�

*/
namespace LG {

	class Math {
		public :
			int add(int a, int b) {
				cout << "LG" << endl;
				return a + b;
			}
		};	
}


namespace Samsung {
	class Math {
	public :
		int add(int a, int b) {
			cout << "Samsung" << endl;
			return a + b;
		}
	};
}

int main() {

	LG::Math math;


	return 0;
}