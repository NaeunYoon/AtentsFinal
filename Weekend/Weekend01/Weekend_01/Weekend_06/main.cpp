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


class Drink {
private:
	string _name;
public:
	Drink(string name)
		:_name(name) {

	}

	string GetName() {
		return _name;
	}
};

class Coffee : public Drink{
private:
	string _name;
public:
	Coffee()
		:Drink("Coffee") {

	}

};

class Latte : public Drink {
private:
	string _name;
public:
	Latte()
		:Drink("Latte") {

	}

};

class Cola : public Drink {
private:
	string _name;
public:
	Cola()
		:Drink("Cola") {

	}
};


class Barista {

public:
	void MakeADrink(Drink& drink) {
		cout << drink.GetName() << "�� �����" << endl << endl;
	}


};

class Casher {

private:
	Barista& _ref; //���� (����)

public:
	Casher(Barista& ref)
		: _ref(ref) {}
	//�����ε��� ���� �������� ������ �Լ�
	void OrderedDrink(Drink& drink) {
		cout << drink.GetName() << "�ֹ��� �޽��ϴ�" << endl;
		_ref.MakeADrink(drink);

	}
};

class Guest {
public:
	void OrderingDrink(Casher& casher, Drink& drink) {	//������ ���� : �ʿ��� �� ������ �Ű������� �޾Ƽ� ���� ó���� ������ ����
		cout << drink.GetName() << "�� �ֹ��մϴ�" << endl;
		casher.OrderedDrink(drink);
	}

};

int main() {

	Guest guest;
	Barista barista;
	Casher casher(barista);

	Coffee coffee;
	Latte latte;
	Cola cola;

	guest.OrderingDrink(casher, coffee);
	guest.OrderingDrink(casher, latte);
	guest.OrderingDrink(casher, cola);
	return 0;

}