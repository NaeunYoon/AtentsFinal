#include <iostream>

using namespace std;

class CannonArm {
private:
    string _name;
public:
    CannonArm()
        : _name("CannonArm")
    {
    }

    void info() {
        cout << _name;
    }
};

class RocketArm {
private:
    string _name;
public:
    RocketArm()
        : _name("RocketArm")
    {
    }

    void info() {
        cout << _name;
    }
};

class CannonArmRobot {
private:
    CannonArm _leftArm, _rightArm;   // 포함 composition

public:
    CannonArmRobot() {}

    void info() {
        cout << "LeftArm: ";
        _leftArm.info();
        cout << endl;
        cout << "RightArm: ";
        _rightArm.info();
        cout << endl << endl;
    }
};

class RocketArmRobot {
private:
    RocketArm _leftArm, _rightArm;   // 포함 composition

public:
    RocketArmRobot() {}

    void info() {
        cout << "LeftArm: ";
        _leftArm.info();
        cout << endl;
        cout << "RightArm: ";
        _rightArm.info();
        cout << endl << endl;
    }
};

int main() {
    CannonArmRobot cannonArmRobot;
    cannonArmRobot.info();

    RocketArmRobot rocketArmRobot;
    rocketArmRobot.info();


    return 0;
}