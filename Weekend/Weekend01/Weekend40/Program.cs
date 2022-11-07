using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster;

namespace Weekend40
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Dragon drangonA = new Dragon("dragonA", 100, 20, 50);
            Dragon drangonB = new Dragon("dragonB", 120, 30, 55);

            drangonA.Attack(drangonB);

            drangonB.Info();


            Ogre ogreA = new Ogre("OgreA", 30, 8, 20);
            Ogre ogreB = new Ogre("OgreB", 35, 10, 22);

            ogreA.Attack(ogreB);
            ogreB.Info();

            ogreB.Attack(drangonA);
            drangonA.Attack(ogreB);

            NAEUN naeunA = new NAEUN("NAEUN A", 100, 100, 100);
            NAEUN naeunB = new NAEUN("NAEUN B", 200, 200, 200);

            naeunA.Attack(drangonA);
            drangonA.Info();

            naeunB.Attack(ogreB);
            ogreB.Info();

            drangonA.Attack(naeunB);
            naeunB.Info();

            ogreA.Attack(naeunA);
            naeunA.Info();

            Slaim slaimA = new Slaim("SlaimA", 15, 8, 10,10);
            Slaim slaimB = new Slaim("SlaimB", 18, 10, 12, 12);

            slaimA.Attack(slaimB);
            slaimB.Info();
            slaimA.Attack(naeunB);
            naeunB.Info();




        }
    }
}
