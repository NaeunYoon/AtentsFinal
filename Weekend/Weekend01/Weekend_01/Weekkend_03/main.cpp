#include <iostream>

using namespace std;
/*
상속이라는 구조보다는 포함이 더 유연해보인다
그럴 때는 과감히 상속을 포기하고 포함을 하는것이 유리하다


*/
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
    Arm* _leftArm, * _rightArm;   // 포함 composition

public:
    Robot(Arm* leftArm, Arm* righArm)
        : _leftArm(leftArm), _rightArm(righArm)
    {}

    void SetLeftArm(Arm* leftArm) {
        _leftArm = leftArm;
    }

    void SetRightArm(Arm* rightArm) {
        _rightArm = rightArm;
    }

    void info() {
        cout << "LeftArm: ";
        _leftArm->info();
        cout << endl;
        cout << "RightArm: ";
        _rightArm->info();
        cout << endl << endl;
    }
};

//class CannonArmRobot : public Robot {
//
//public:
//    CannonArmRobot(CannonArm& leftArm, CannonArm& rightArm)
//        : Robot(leftArm, rightArm)
//    {}
//};
//
//class RocketArmRobot : public Robot {
//public:
//    RocketArmRobot(RocketArm& leftArm, RocketArm& rightArm)
//        : Robot(leftArm, rightArm)
//    {}
//};
//
//class BombArmRobot : public Robot {
//public:
//    BombArmRobot(BombArm& leftArm, BombArm& rightArm)
//        : Robot(leftArm, rightArm) {}
//};




int main() {
    CannonArm cannonArm;
    RocketArm rocketArm;
    BombArm bombArm;

    cout << "cannonArmRobot" << endl;
    Robot cannonArmRobot(&cannonArm, &cannonArm);
    cannonArmRobot.info();
    cout << "rocketArmRobot" << endl;
    Robot rocketArmRobot(&rocketArm, &rocketArm);
    rocketArmRobot.info();
    cout << "bombArmRobot" << endl;
    Robot bombArmRobot(&bombArm, &bombArm);
    bombArmRobot.info();


    return 0;
}