#include <iostream>

/*
���� �θ� �ΰ� �θ��� �Ӽ��� �ڽ��� �������� �� �ִ�
�ٸ� ������ ���߻���� �������� �ʴ´� �ֳĸ� ��ȣ���� ���ܼ�
�׷��� ���߻���� ��ȣ�ؼ� ���� ������ �ϴµ� .. 
�ٵ� �� �θ� �������� ���� �����ϴٰ� �� ����Ʈ + �� : �������ΰ͵鳢���� ������

���� 
���߻���� �ؼ� smartphone�� �۵��ǵ��� �غ�����
����Ʈ���� ����� ����غ�����

��ü������ 3�� �Ӽ�

��ü�� ��ü���� ��ȣ�ۿ��ϴ� ��
�ᱹ a�� b�� ���� �˰� �־�� �� 
b��� ��ü�� ��ȣ�ۿ� �� ������ ������ �־�� �� 
�츰 �װ� public �̶�� ���������ڸ� ����ϴ� ���̴�
a�� public �κ��� �ǵ���� b�� ������ �ϴ� ��

ĸ��ȭ (capsulazation)
��� (inheritance)
������ (polymorphism)

��ü�� ���� �޼����� �ٸ� ������ ���̴� ��
 a��ü�� b��ü�� ������ �� a�� b ��ü�� �޼����� ������ -> � ��ü�� �ٸ� ��ü�� �Լ��� ȣ���Ѵ�
 ���� �Լ��� ȣ���ߴµ� �ٸ� ������ ���̴� ��

 a�� b���� ���Ḧ ����� �޶�� �޼����� ���´µ� � �� �ݶ� � �� ���̴ٸ� 
 ��Ȳ��Ȳ���� �ٸ� ������ ���̴� ��

 �츮�� �������� ���� �� ����ϴ� ������ �����ε� �������̵��� �ִ�
 �����ε� : ���� �̸��� �Լ��� ����� ��
 �������̵� : �θ� Ŭ������ ����Լ��� �ڽ� Ŭ��������������
			  �θ� Ŭ������ �����Լ��� �ڽ� Ŭ�������� ������


*/

using namespace std;


class Tiger {
	public: 
		void Roar() {
			cout << "����" << endl;
		}
		void GetName() {
			cout << "Tiger" << endl;
		}
};

class Lion {
	public:
		void Roar() {
			cout << "������" << endl;
		}
		void GetName() {
			cout << "Lion" << endl;
		}
};

class Elephant {
	public:
		void Roar() {
			cout << "�ѿ�" << endl;
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

