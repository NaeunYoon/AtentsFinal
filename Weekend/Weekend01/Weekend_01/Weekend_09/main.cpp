/*
�����Լ�


*/

#include <iostream>

using namespace std;

class Parent {
public:
    void Print() {      // �Ϲ� ����Լ�
        cout << "Parent::Print()" << endl;
    }

    virtual void Info() {   // �����Լ�
        cout << "Parent::Info()" << endl;
    }

    virtual void Info2() {   // �����Լ�
        cout << "Parent::Info2()" << endl;
    }
};

class Child1 : public Parent {
public:
    void Print() {      // �Ϲ� ����Լ�
        cout << "Child1::Print()" << endl;
    }

    void Info() override {   // �����Լ�
        cout << "Child1::Info()" << endl;
    }

};


class Child2 : public Parent {
public:
    void Print() {      // �Ϲ� ����Լ�
        cout << "Child2::Print()" << endl;
    }

    void Info2() override {   // �����Լ�
        cout << "Child2::Info()" << endl;
    }

};


void PrintFunction(Parent& ref) {   // �Ϲݸ���Լ� ȣ��
                                    //� Ÿ���� �������� ���� parent�� ����Ʈ �Լ��� ����
                                    //������ Ÿ�ӿ� � �Լ��� ȣ������ ������ ���ϴ�
                                    //���� ���ε� �̶�� �Ѵ�
    ref.Print();
}


void InfoFunction(Parent& ref) {   // �����Լ� ȣ��
    //������ Ÿ�ӿ� � �Լ��� ȣ������ ������ ���� ����
    //�������ε� (�����߿� ����� �Լ��� ȣ������ ������ �մϴ�
    ref.Info();
}

int main() {
    Parent parent;
    Child1 child1;
    Child2 child2;

    // �Ϲ��Լ� ȣ��
    PrintFunction(parent);
    PrintFunction(child1);
    PrintFunction(child2);


    // �����Լ� ȣ��
    InfoFunction(parent);
    InfoFunction(child1);
    InfoFunction(child2);


    return 0;


    /*
    ���� ����Ŭ������ �ϳ��� ������ �ִ� �Լ��� �߻�Ŭ������� �Ѵ�
    �����ΰ� �ʿ���� virtual �Լ�
    �߻�Ŭ������ �Ǹ� �ڱ� �ڽ��� ��ü�� ���� �� �ִ� �ɷ��� ��ǵȴ�
    �׷��� �߻�Ŭ������ ���� �����Լ��� �ڽ��� ���鵵�� ������ �� �ִ�
    
    */
}