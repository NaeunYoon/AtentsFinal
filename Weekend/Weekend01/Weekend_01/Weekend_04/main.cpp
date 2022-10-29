#include <iostream>

/*
여러 부모를 두고 부모의 속성을 자식이 물려받을 수 있다
다른 언어들은 다중상속을 지원하지 않는다 왜냐면 모호함이 생겨서
그래서 다중상속을 모호해서 하지 말라고는 하는데 .. 
근데 두 부모가 이질적일 떄는 가능하다고 함 스마트 + 폰 : 이질적인것들끼리는 괜찮음

숙제 
다중상속을 해서 smartphone이 작동되도록 해보세요
스마트폰의 기능을 사용해보세요

객체지향의 3대 속성

객체와 객체끼리 상호작용하는 것
결국 a와 b는 서로 알고 있어야 함 
b라는 객체가 상호작용 할 뭔가를 가지고 있어야 함 
우린 그걸 public 이라는 접근제어자를 사용하는 것이다
a는 public 부분을 건드려서 b와 소통을 하는 것

캡슐화 (capsulazation)
상속 (inheritance)
다형성 (polymorphism)

객체가 같은 메세지에 다른 반응을 보이는 것
 a객체가 b객체랑 소통할 떄 a가 b 객체에 메세지를 보낸다 -> 어떤 객체가 다른 객체의 함수를 호출한다
 같은 함수를 호출했는데 다른 반응을 보이는 것

 a가 b한테 음료를 만들어 달라는 메세지를 보냈는데 어떨 땐 콜라 어떨 땐 사이다를 
 상황상황마다 다른 반응을 보이는 것

 우리가 다형성을 보일 때 사용하는 도구는 오버로딩 오버라이딩이 있다
 오버로딩 : 같은 이름의 함수를 만드는 것
 오버라이딩 : 부모 클래스의 멤버함수를 자식 클래스에서재정의
			  부모 클래스의 가상함수를 자식 클래스에서 재정의


*/

using namespace std;


class Tiger {
	public: 
		void Roar() {
			cout << "어흥" << endl;
		}
		void GetName() {
			cout << "Tiger" << endl;
		}
};

class Lion {
	public:
		void Roar() {
			cout << "으르렁" << endl;
		}
		void GetName() {
			cout << "Lion" << endl;
		}
};

class Elephant {
	public:
		void Roar() {
			cout << "뿌우" << endl;
		}
		void GetName() {
			cout << "Elephant" << endl;
		}
};

class Liger : public Tiger, public Lion, public Elephant
{
	public:
		void GetName() {
			cout << "Liger" << endl;
		}

};

class SmartPhone {

};

int main() {

	Lion liger;
	liger.Roar();
	liger.Lion::Roar();
	//liger.Elephant::Roar();

	return 0;
}

