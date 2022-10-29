#include<iostream>

using namespace std;

//ī�� ���� ���α׷�
//ī�信�� � ������ �ֳ���?
//�ٸ���Ÿ

//ī�信 ����.. Ŀ�Ǹ� ���Ѽ� ���� �帧�� �����Ѵ�
//���ҿ� ���� å���� �ľ� �� �̴ϴ�

//�ٸ���Ÿ barista : Ŀ��Ÿ�ִ� ����
//ĳ�� casher : ����� 
//�մ� guest : �ֹ��� �ϴ� å��

//�Խ�Ʈ�� ĳ�Ŵ� �ֹ��� ���� �Ͻ������� ������ ����
//ĳ�ſ� �ٸ���Ÿ�� ��� ���� ����

class Coffee {
	private:
		string _name;
	public:
		Coffee()
			:_name("Coffee") {

		}

		string GetName() {
			return _name;
		}
};

class Latte {
private:
	string _name;
public:
	Latte()
		:_name("Latte") {

	}

	string GetName() {
		return _name;
	}
};

class Cola {
private:
	string _name;
public:
	Cola()
		:_name("Cola") {

	}

	string GetName() {
		return _name;
	}
};


class Barista {

public:
	void MakeADrink(Coffee& drink) {
		cout << drink.GetName()<<"�� �����" << endl << endl;
	}

	void MakeADrink(Latte& drink) {
		cout << drink.GetName() << "�� �����" << endl << endl;
	}
	void MakeADrink(Cola& drink) {
		cout << drink.GetName() << "�� �����" << endl << endl;
	}

};

class Casher {

private:
	Barista& _ref; //���� (����)

public:
	Casher(Barista& ref) 
		: _ref(ref){}
	//�����ε��� ���� �������� ������ �Լ�
	void OrderedDrink(Coffee& drink) {
		cout << drink.GetName() << "�ֹ��� �޽��ϴ�" << endl;
		_ref.MakeADrink(drink);
		
	}

	void OrderedDrink(Latte& drink) {
		cout << drink.GetName() << "�ֹ��� �޽��ϴ�" << endl;
		_ref.MakeADrink(drink);
	}

	void OrderedDrink(Cola& drink) {
		cout << drink.GetName() << "�ֹ��� �޽��ϴ�" << endl;
		_ref.MakeADrink(drink);
	}
};

class Guest {
	public:
		void OrderingDrink(Casher& casher, Coffee &drink) {	//������ ���� : �ʿ��� �� ������ �Ű������� �޾Ƽ� ���� ó���� ������ ����
			cout << drink.GetName() << "�� �ֹ��մϴ�" << endl;
			casher.OrderedDrink(drink);
		}
		void OrderingDrink(Casher& casher, Latte& drink) {	//������ ���� : �ʿ��� �� ������ �Ű������� �޾Ƽ� ���� ó���� ������ ����
			cout << drink.GetName() << "�� �ֹ��մϴ�" << endl;
			casher.OrderedDrink(drink);
		}
		void OrderingDrink(Casher& casher, Cola& drink) {	//������ ���� : �ʿ��� �� ������ �Ű������� �޾Ƽ� ���� ó���� ������ ����
			cout << drink.GetName() << "�� �ֹ��մϴ�" << endl;
			casher.OrderedDrink(drink);
		}
};

int main(){

	Guest guest;
	Barista barista;
	Casher casher(barista);

	Coffee coffee;
	Latte latte;
	Cola cola;

	guest.OrderingDrink(casher,coffee);
	guest.OrderingDrink(casher, latte);
	guest.OrderingDrink(casher, cola);
	return 0;

	}