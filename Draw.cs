using System;
using System.Collections.Generic;

namespace Bingo_Number_Generator
{
    class Draw
    {

        public int upperlimit;
        public List<int> DrawStorage;
        ///public List<int> SortedOrder; 

        Random rand = new Random();

        public Draw(int limit)
        {
            this.upperlimit = limit;
            this.DrawStorage = new List<int>();

        }
         public void mainMenu()
        {  
            Console.WriteLine("Welcome to the Swinburne Bingo Club");
            Console.WriteLine("1. Draw next number");
            Console.WriteLine("2. View all drawn numbers");
            Console.WriteLine("3. Check specific number");
            Console.WriteLine("4. Enter a list of numbers to check against drawn list");
            Console.WriteLine("5. Exit");
        }
        public void viewAllDrawnnums()
        {

            //console writlien 1 option as they were drawn
            this.DrawStorage.ForEach(Console.WriteLine);
            ///option two they get srtoed into numercial order - might have to make a new list to copy them and sort them
            

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
            ///SortedOrder.add(radnnum); this list then gets sorted when you access it to print for option3.ii 

        }

        public void getupperLimit()
        {

            bool goOn = false;
            while (!goOn)
            {
                System.Console.WriteLine("Please enter an upper limit for your bingo # range");
                var userInput = "furfhf";
                var userInput_1 = Convert.ToInt32(userInput);
                
                int result = 0;
                if (int.TryParse(userInput, out result))
                {
                
                Console.WriteLine(result + " .... really?" + " Only Numbers Please... try again");
                continue;

                }

                if (userInput_1 <= 0)
                {
                    Console.WriteLine(result + " .... really?" + " Only Positive Numbers Please .. try again");
                    continue;
                }
                
                else
                {
                    System.Console.WriteLine("You have set your upper limit");
                    userInput_1 = this.upperlimit;

                    goOn = true;
                       
                }

            }
            
            mainMenu();

        }

        public void checkNuminList()
        {

            Console.WriteLine("Enter your number to check if it has been drawn..");
            string targetInt = Console.ReadLine();
            int number;
            if (Int32.TryParse(targetInt, out number))
            {
                bool keepGoing = true;
                while (keepGoing)
                {
                
                    int newInt = Convert.ToInt32(targetInt);// now that im past the sentinel value need to work with an int
                    int index = DrawStorage.IndexOf(newInt); ///this checks ans sees if the targetint is in the list
                    if (index >= 0)//if it is there it reurns a "1"
                    {
                        Console.WriteLine(newInt + " Has been located, and i can confirm it has been drawn previously");
                    }
                    else
                    {
                        Console.WriteLine("Your number has not been drawn - its fresh");

                    }
                    
                    bool validInput = false;
                    
                    while (!validInput)
                    {
                        Console.WriteLine("\nTo check another number press 1 ");
                        Console.WriteLine(" Otherwise press 2 to return to main menu");
                        /////needs ome validation here (loop)
                        var userChoice = Console.Read();///if i use the .read here it gets the ASCI value for that character - so this way it it has
                        if (userChoice == 49) /// using 
                        {
                            keepGoing = true;
                            validInput = true;
                        }
                        else if (userChoice == 50)
                        {
                            keepGoing = false;
                            validInput = true;
                        }
                        else
                        {
                            System.Console.WriteLine("invalid input");///need to then return it to the top of the list
                        }
                    }

                }


            }
            else
            {
                Console.WriteLine("You failed to enter a readable selection - please try again");
            }    
            



        }

    }


}
