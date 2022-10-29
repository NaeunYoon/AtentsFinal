/*
데이터타입의 일반화 프로그래밍
템플릿이라는 기능으로 c++에서 쓴다
자동으로 함수를 만들어준다

네임스페이스
*/

#include <iostream>
using namespace std;



/*
같은 회사 안에서도 여러가지 네임스페이스르 가지고 있다

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