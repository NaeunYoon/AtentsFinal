#include<iostream>

using namespace std;

//���� ����� å���� �ٸ���Ÿ������ 
//�̹����� ���� ����� å���� �������� �����غ���
//�׷� Ÿ�Ժ����� �ʿ� ������


//enum DrinkType {
//	COFFEE,
//	LATTE,
//	COLA,
//	TEA,
//	CIDAR
//};


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

	virtual void MakeADrink() {	
		//�Ϲ� ��� �Լ� : ��� �۵��ϳĸ� �׸��� Ÿ�Կ� ���� �۵�
		//���� virtual�̶�� �����Լ��� ������ش�
		//���� �Լ��� ����ִ� Ÿ�Կ� ���� �۵��Ѵ�
		cout << "���Ḧ ����ϴ�" << endl << endl;
	}

};


class Coffee : public Drink {
public:
	Coffee()
		:Drink("Coffee") {
	}

	void MakeADrink() {
		cout << "Ŀ�Ǹ� ����ϴ�" << endl<<endl;
	}

};

class Latte : public Drink {
public:
	Latte()
		:Drink("Latte") {
	}
	void MakeADrink() {
		cout << "�󶼸� ����ϴ�" << endl<<endl;
	}
};

class Cola : public Drink {
public:
	Cola()
		:Drink("Cola") {
	}
	void MakeADrink() {
		cout << "�ݶ� ����ϴ�" << endl<<endl;
	}
};

class Tea : public Drink {
public:
	Tea()
		:Drink("Tea") {
	}
	void MakeADrink() {
		cout << "���� ����ϴ�" << endl<<endl;
	}
};

class Cidar : public Drink {
public:
	Cidar()
		:Drink("Cidar") {
	}
	void MakeADrink() {
		cout << "���̴ٸ� ����ϴ�" << endl<<endl;
	}
};

class Barista {

public:
	void MakeADrink(Drink& drink) {
		cout << drink.GetName() << "�� ����� ���� ��ŵ�ϴ�" << endl;
		drink.MakeADrink();

		


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