#include<iostream>

using namespace std;

//카페 관리 프로그램
//카페에는 어떤 역할이 있나요?
//바리스타

//카페에 가서.. 커피를 시켜서 업무 흐름을 봐야한다
//역할에 따른 책임이 파악 될 겁니다

//바리스타 barista : 커피타주는 역할
//캐셔 casher : 돈계산 
//손님 guest : 주문을 하는 책임

//게스트와 캐셔는 주문할 때만 일시적으로 만나는 관계
//캐셔와 바리스타는 계속 보는 관계

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
		cout << drink.GetName()<<"을 만든다" << endl << endl;
	}

	void MakeADrink(Latte& drink) {
		cout << drink.GetName() << "을 만든다" << endl << endl;
	}
	void MakeADrink(Cola& drink) {
		cout << drink.GetName() << "을 만든다" << endl << endl;
	}

};

class Casher {

private:
	Barista& _ref; //참조 (포함)

public:
	Casher(Barista& ref) 
		: _ref(ref){}
	//오버로딩을 통해 다형성을 구현한 함수
	void OrderedDrink(Coffee& drink) {
		cout << drink.GetName() << "주문을 받습니다" << endl;
		_ref.MakeADrink(drink);
		
	}

	void OrderedDrink(Latte& drink) {
		cout << drink.GetName() << "주문을 받습니다" << endl;
		_ref.MakeADrink(drink);
	}

	void OrderedDrink(Cola& drink) {
		cout << drink.GetName() << "주문을 받습니다" << endl;
		_ref.MakeADrink(drink);
	}
};

class Guest {
	public:
		void OrderingDrink(Casher& casher, Coffee &drink) {	//의존적 관계 : 필요할 떄 인자의 매개변수로 받아서 서로 처리가 끝나면 ㅂㅂ
			cout << drink.GetName() << "를 주문합니다" << endl;
			casher.OrderedDrink(drink);
		}
		void OrderingDrink(Casher& casher, Latte& drink) {	//의존적 관계 : 필요할 떄 인자의 매개변수로 받아서 서로 처리가 끝나면 ㅂㅂ
			cout << drink.GetName() << "를 주문합니다" << endl;
			casher.OrderedDrink(drink);
		}
		void OrderingDrink(Casher& casher, Cola& drink) {	//의존적 관계 : 필요할 떄 인자의 매개변수로 받아서 서로 처리가 끝나면 ㅂㅂ
			cout << drink.GetName() << "를 주문합니다" << endl;
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