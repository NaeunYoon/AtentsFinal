#include<iostream>

using namespace std;

//음료 만드는 책임이 바리스타였지만 
//이번에는 음료 만드는 책임을 음료한테 전가해보자
//그럼 타입변수가 필요 없어짐


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
		//일반 멤버 함수 : 어떻게 작동하냐면 그릇의 타입에 따라 작동
		//따라서 virtual이라는 가상함수로 만들어준다
		//가상 함수는 담겨있는 타입에 따라서 작동한다
		cout << "음료를 만듭니다" << endl << endl;
	}

};


class Coffee : public Drink {
public:
	Coffee()
		:Drink("Coffee") {
	}

	void MakeADrink() {
		cout << "커피를 만듭니다" << endl<<endl;
	}

};

class Latte : public Drink {
public:
	Latte()
		:Drink("Latte") {
	}
	void MakeADrink() {
		cout << "라떼를 만듭니다" << endl<<endl;
	}
};

class Cola : public Drink {
public:
	Cola()
		:Drink("Cola") {
	}
	void MakeADrink() {
		cout << "콜라를 만듭니다" << endl<<endl;
	}
};

class Tea : public Drink {
public:
	Tea()
		:Drink("Tea") {
	}
	void MakeADrink() {
		cout << "차를 만듭니다" << endl<<endl;
	}
};

class Cidar : public Drink {
public:
	Cidar()
		:Drink("Cidar") {
	}
	void MakeADrink() {
		cout << "사이다를 만듭니다" << endl<<endl;
	}
};

class Barista {

public:
	void MakeADrink(Drink& drink) {
		cout << drink.GetName() << "을 만드는 것을 시킵니다" << endl;
		drink.MakeADrink();

		


	}


};

class Casher {

private:
	Barista& _ref; //참조 (포함)

public:
	Casher(Barista& ref)
		: _ref(ref) {}
	//오버로딩을 통해 다형성을 구현한 함수
	void OrderedDrink(Drink& drink) {
		cout << drink.GetName() << "주문을 받습니다" << endl;
		_ref.MakeADrink(drink);

	}
};

class Guest {
public:
	void OrderingDrink(Casher& casher, Drink& drink) {	//의존적 관계 : 필요할 떄 인자의 매개변수로 받아서 서로 처리가 끝나면 ㅂㅂ
		cout << drink.GetName() << "를 주문합니다" << endl;
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