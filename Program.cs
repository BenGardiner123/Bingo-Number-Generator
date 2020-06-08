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
            d1.DrawStorage.ForEach(Console.WriteLine);//this is a really cool way of doing it because this methid chooses the right type for the list.
            
            

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
        public Draw draw;
        public List<int> userCheckList;

        public Interface()
        {
        
        }

        public void startMenu()
        {
            System.Console.WriteLine("Please enter an upper limit for your bingo # range");
            var userInt = Convert.ToInt32(Console.ReadLine()); /// need to insert a try catch here
            draw = new Draw(userInt);
            Console.WriteLine("Welcome to the Swinburne Bingo Club");
            Console.WriteLine("1. Draw next number");
            Console.WriteLine("2. View all drawn numbers");
            Console.WriteLine("3. Check specific number");
            Console.WriteLine("4. Enter a list of numbers to check against drawn list");
            Console.WriteLine("5. Exit");
        
            try
            {
                int userinput = Convert.ToInt32(Console.ReadLine()); // need another try catcah here
            }
            catch (System.NullReferenceException)
            {
                
                throw;
            }
            
            
        
        }

        public void viewAllDrawnnums(){

            this.draw.DrawStorage.ForEach(Console.WriteLine);
                

            
        }

        public void checkNuminList(){

            

        }


    }


}
