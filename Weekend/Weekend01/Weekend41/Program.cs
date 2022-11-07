using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster;
using Weekend41;

namespace Weekend41
{

    internal class Program
    {
        static void Main(string[] args)
        {
            /*Monster.Monster monster = new Monster.Monster();*/    //추상클래스는 객체를 만들 수 없다
                                                               //자기 자신의 객체를 만들 수 있는 능력 상실


            Dragon drangonA = new Dragon("dragonA", 100, 20, 50);
            Dragon drangonB = new Dragon("dragonB", 120, 30, 55);

            Ogre ogreA = new Ogre("OgreA", 30, 8, 20);
            Ogre ogreB = new Ogre("OgreB", 35, 10, 22);
           
            NAEUN naeunA = new NAEUN("NAEUN A", 100, 100, 100);
            NAEUN naeunB = new NAEUN("NAEUN B", 200, 200, 200);

            Slaim slaimA = new Slaim("SlaimA", 15, 8, 10, 10);
            Slaim slaimB = new Slaim("SlaimB", 18, 10, 12, 12);

            Goblin goblin = new Goblin("goblin", 10, 10, 10);

            drangonA.Attack(drangonB);
            drangonB.Info();

            ogreA.Attack(ogreB);
            ogreB.Info();

            ogreB.Attack(drangonA);
            drangonA.Info();

            drangonA.Attack(ogreB);
            ogreB.Info();

            naeunA.Attack(drangonA);
            drangonA.Info();

            naeunB.Attack(ogreB);
            ogreB.Info();

            drangonA.Attack(naeunB);
            naeunB.Info();

            ogreA.Attack(naeunA);
            naeunA.Info();

            slaimA.Attack(slaimB);
            slaimB.Info();

            slaimA.Attack(naeunB);
            naeunB.Info();

            goblin.Attack(naeunB);
            naeunB.Info();

            Golem golem = new Golem("Golem", 38, 20, 22, 42);
            drangonA.Attack(golem);
            golem.Info();

            Snake snake = new Snake("Snake",20,20,20,20);
            golem.Attack(snake);



        }
    }
}
