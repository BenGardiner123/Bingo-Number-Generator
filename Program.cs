using System;
using System.Collections.Generic;

namespace Bingo_Number_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Draw {
        public int min;
        public int upperlimit;
        public List<int> DrawStorage;

        Random rand = new Random();

        public Draw(int upperlimit)
        {

            this.upperlimit = upperlimit;
            this.DrawStorage = new List<int>();

        }

        public void DrawNextNum(){
            bool validNum = false;
            var randnum = rand.Next(1, this.upperlimit);
            while (validNum == false)




            return randnum;
        }
        

    }

    class Interface {






    }








}
