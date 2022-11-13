#include <iostream>
#include <string>

using namespace std;

template <typename T>
T add(T a, T b) {
	return a + b;
}

/*
int add(int a, int b) {
   return a + b;
}

float add(float a, float b) {
   return a + b;
}

double add(double a, double b) {
   return a + b;
}

string add(string a, string b) {
   return a + b;
}
*/

int main() {

	int a = 20;
	int b = 30;
	float c = 1.2f;
	float d = 3.4f;
	double e = 102.3;
	double f = 200.1231;

	string g = "mosnter";
	string h = " is World!!";

	cout << a << " + " << b << " = " << add(a, b) << endl;
	cout << c << " + " << d << " = " << add(c, d) << endl;
	cout << e << " + " << f << " = " << add(e, f) << endl;
	cout << g << " + " << h << " = " << add(g, h) << endl;


	return 0;
}