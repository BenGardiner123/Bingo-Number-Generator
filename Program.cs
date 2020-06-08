using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo_Number_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Console.WriteLine("Please enter suer upper limit");
            var userInt = 99;
            Draw d1 = new Draw(userInt);
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawStorage.ForEach(Console.WriteLine);
            
            

        }
    }

    class Draw {
        
        public int upperlimit;
        public List<int> DrawStorage;

        Random rand = new Random();

        public Draw(int limit)
        {
            this.upperlimit = limit;
            this.DrawStorage = new List<int>();

        }

        public void DrawNextNum(){
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

    class Interface {






    }








}
