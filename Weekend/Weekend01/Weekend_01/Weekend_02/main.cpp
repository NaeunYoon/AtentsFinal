#include <iostream>

using namespace std;

class Arm {
private:
    string _name;

public:
    Arm(string name)
        : _name(name) {}

    void info() {
        cout << _name;
    }

};

class CannonArm : public Arm {

public:
    CannonArm()
        : Arm("CannonArm")
    {
    }
};

class BombArm : public Arm {
public:
    BombArm()
        :Arm("BombArm") {}
};

class RocketArm : public Arm {

public:
    RocketArm()
        : Arm("RocketArm")
    {
    }
};

class Robot {
private:
    Arm& _leftArm, & _rightArm;   // Æ÷ÇÔ composition

public:
    Robot(Arm& leftArm, Arm& righArm)
        : _leftArm(leftArm), _rightArm(righArm)
    {}

    void info() {
        cout << "LeftArm: ";
        _leftArm.info();
        cout << endl;
        cout << "RightArm: ";
        _rightArm.info();
        cout << endl << endl;
    }
};

class CannonArmRobot : public Robot {

public:
    CannonArmRobot(CannonArm& leftArm, CannonArm& rightArm)
        : Robot(leftArm, rightArm)
    {}
};

class RocketArmRobot : public Robot {
public:
    RocketArmRobot(RocketArm& leftArm, RocketArm& rightArm)
        : Robot(leftArm, rightArm)
    {}
};

class BombArmRobot : public Robot {
public:
    BombArmRobot(BombArm& leftArm, BombArm& rightArm)
        : Robot(leftArm, rightArm) {}
};

int main() {
    CannonArm cannonArm;
    RocketArm rocketArm;
    BombArm bombArm;


    CannonArmRobot cannonArmRobot(cannonArm, cannonArm);
    cannonArmRobot.info();

    RocketArmRobot rocketArmRobot(rocketArm, rocketArm);
    rocketArmRobot.info();

    BombArmRobot bombArmRobot(bombArm, bombArm);
    bombArmRobot.info();


    return 0;
}