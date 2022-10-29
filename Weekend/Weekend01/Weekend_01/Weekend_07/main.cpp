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


enum DrinkType {
	COFFEE,
	LATTE,
	COLA,
	TEA,
	CIDAR
};


class Drink {
private:
	string _name;
	DrinkType _type;

public:
	Drink(string name, DrinkType type)
		:_name(name), _type(type) {

	}

	string GetName() {
		return _name;
	}

	DrinkType GetType() {
		return _type;
	}

};


class Coffee : public Drink {
public:
	Coffee()
		:Drink("Coffee",COFFEE) {

	}
};

class Latte : public Drink {
public:
	Latte()
		:Drink("Latte",LATTE) {

	}
};

class Cola : public Drink {
public:
	Cola()
		:Drink("Cola",COLA) {
	}
};

class Tea : public Drink {
public:
	Tea()
		:Drink("Tea", TEA) {
	}
};

class Cidar : public Drink {
public:
	Cidar()
		:Drink("Cidar",CIDAR) {
	}
};

class Barista {

public:
	void MakeADrink(Drink& drink) {
		/*cout << drink.GetName() << "�� �����" << endl << endl;*/

		switch (drink.GetType())
		{
		case COFFEE :
			cout << drink.GetName() << "�� ����ϴ�" << endl << endl;
			break;
		case LATTE :
			cout << drink.GetName() << "�� ����ϴ�" << endl << endl;
			break;
		case COLA :
			cout << drink.GetName() << "�� ����ϴ�" << endl << endl;
			break;
		case TEA :
			cout << drink.GetName() << "�� ����ϴ�" << endl << endl;
			break;
		case CIDAR:
			cout << drink.GetName() << "�� ����ϴ�" << endl << endl;
			break;

		}


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