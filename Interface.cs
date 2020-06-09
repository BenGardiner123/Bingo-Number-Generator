using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bingo_Number_Generator
{
    class Interface
    {
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




        }

        public void viewAllDrawnnums()
        {

            //console writlien 1 option as they were drawn
            this.draw.DrawStorage.ForEach(Console.WriteLine);
            ///option two they get srtoed into numercial order - might have to make a new list to copy them and sort them


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
                    int index = draw.DrawStorage.IndexOf(newInt); ///this checks ans sees if the targetint is in the list
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




