using System;
using System.Collections.Generic;

namespace Bingo_Number_Generator
{
    class Draw
    {

        public int upperlimit;
        public List<int> DrawStorage;

        Random rand = new Random();

        public Draw(int limit)
        {
            this.upperlimit = limit;
            this.DrawStorage = new List<int>();

        }

        public void DrawNextNum()
        {
            var validNum = false; // exit condition

            var randnum = rand.Next(1, this.upperlimit);


            while (validNum == false)
            {
                if (!DrawStorage.Contains(randnum))
                {
                    validNum = true;
                }
                else
                {
                    randnum = rand.Next(1, this.upperlimit);
                }


            }

            DrawStorage.Add(randnum);

        }

    }


}
