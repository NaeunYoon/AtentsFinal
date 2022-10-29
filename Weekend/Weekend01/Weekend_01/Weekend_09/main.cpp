/*
가상함수


*/

#include <iostream>

using namespace std;

class Parent {
public:
    void Print() {      // 일반 멤버함수
        cout << "Parent::Print()" << endl;
    }

    virtual void Info() {   // 가상함수
        cout << "Parent::Info()" << endl;
    }

    virtual void Info2() {   // 가상함수
        cout << "Parent::Info2()" << endl;
    }
};

class Child1 : public Parent {
public:
    void Print() {      // 일반 멤버함수
        cout << "Child1::Print()" << endl;
    }

    void Info() override {   // 가상함수
        cout << "Child1::Info()" << endl;
    }

};


class Child2 : public Parent {
public:
    void Print() {      // 일반 멤버함수
        cout << "Child2::Print()" << endl;
    }

    void Info2() override {   // 가상함수
        cout << "Child2::Info()" << endl;
    }

};


void PrintFunction(Parent& ref) {   // 일반멤버함수 호출
                                    //어떤 타입이 들어오던지 간에 parent의 프린트 함수가 나옴
                                    //컴파일 타임에 어떤 함수를 호출할지 결정이 납니다
                                    //정적 바인딩 이라고 한다
    ref.Print();
}


void InfoFunction(Parent& ref) {   // 가상함수 호출
    //컴파일 타임에 어떤 함수를 호출할지 결정할 수가 없다
    //동적바인딩 (실행중에 어디의 함수를 호출할지 결정을 합니다
    ref.Info();
}

int main() {
    Parent parent;
    Child1 child1;
    Child2 child2;

    // 일반함수 호출
    PrintFunction(parent);
    PrintFunction(child1);
    PrintFunction(child2);


    // 가상함수 호출
    InfoFunction(parent);
    InfoFunction(child1);
    InfoFunction(child2);


    return 0;


    /*
    순수 가상클래스를 하나라도 가지고 있는 함수를 추상클래스라고 한다
    구현부가 필요없는 virtual 함수
    추상클래스가 되면 자기 자신의 객체를 만들 수 있는 능력이 상실된다
    그러나 추상클래스의 순수 가상함수를 자식이 만들도록 강제할 수 있다
    
    */
}