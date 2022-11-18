using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_52
{
    delegate bool CompareDelegate(object arg1, object arg2);

    class SortObject
    {
        object[] things;

        public SortObject(object[] things)
        {
            this.things = things;
        }

        public void Sort (CompareDelegate compareMethod)
        {
            object tmp;

            for (int i = 0; i < things.Length; i++)
            {
                int lowPos=i;

                for (int j = i+1; j < things.Length; j++)
                {
                    if (compareMethod(things[j], things[lowPos]))
                    {
                        lowPos = j;
                    }
                }
                tmp = things[lowPos];
                things[lowPos] = things[i];
                things[i] = tmp;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
