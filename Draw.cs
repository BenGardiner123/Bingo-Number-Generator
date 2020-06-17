using System;
using System.Collections.Generic;

namespace Bingo_Number_Generator
{
    class Draw
    {

        public int upperlimit;
        public List<int> DrawStorage;
        ///public List<int> SortedOrder; // thinking to use another list to sort..!--.!-- not sure i need it tho

        Random rand = new Random();

        public Draw(int limit)
        {
            this.upperlimit = limit;
            this.DrawStorage = new List<int>();

        }
         public void mainMenu()
        {  
            ///think i need to have some kind of condition here to catch the exit button--- so keep coming back to the top here and choosing numbers unitl "5" gets enetered.
            int validInput = 0; // this is going to be the menu num
            while (validInput != 5)
            {
                Console.WriteLine("Welcome to the Swinburne Bingo Club");
                Console.WriteLine("1. Draw next number");
                Console.WriteLine("2. View all drawn numbers");
                Console.WriteLine("3. Check specific number");
                Console.WriteLine("4. Enter a list of numbers to check against drawn list");
                Console.WriteLine("5. Exit");

            ///2.	Upon pressing “1” a new number is drawn
            ///i.	No duplicate numbers should be drawn
            ///ii.	No negative numbers should be drawn
            ///im thinking i use the same functionality of the upper limit menu to try and force correct input.

            
                bool goOn = false; // exit value for my while loop
                while (!goOn)
                {
                    string userInput = Console.ReadLine(); // store the user choice from the menu
                    
                    if (int.TryParse(userInput, out validInput)) /// so this will test whether the input is parsable - if not then it should go to the else and then give them the message and then return to the top
                    {
                        if (validInput >= 0 &&  validInput <= 5) //so here is the first test - need to check that the number is in the range of the menu - so need to set something at the top.
                        {
                          goOn = true;
                        }    
                        else // if it comes here that means that the result was not greater than 0... so a -1 etc... we cant have that so
                        {
                            Console.WriteLine (  " Only numbers please " + " Please choose a number from the menu.. try again");
                        }

                    }
                    else
                    {
                        Console.WriteLine(" .... really? " + " Please enter just a number.. no words .. try again"); /// again thsi catches the non - numercial input.
                    }

                }
                
                mainMenu();

            }




        }

        ///3.	Upon pressing “2” all drawn numbers should be printed
        ///i.	Provide an option to print all numbers in the order that they were drawn
        ///ii.	Provide an option to print all numbers in numerical order

        /// 4.	Upon pressing “3” user is prompted to enter numbers one by one to check if they have been drawn

        ///5.	Upon pressing “4” the program will exit 
    


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
                var userInput = Console.ReadLine();
                
                
                int result = 0;
                if (int.TryParse(userInput, out result)) /// so this will test whter the input is aprsable - if not then it should go to the else and then give them the message and then return to the top
                {
                    if (result > 0)
                    {
                        Console.WriteLine(result + " excellent choice " + result + " is a fine number");
                        goOn = true; /// so if the loop gets here it's passed the parse test.!-- We would then want the loop to exit
                        upperlimit = result;
                    }
                    else // if it comes here that means that the result was not greater than 0... so a -1 etc... we cant have that so
                    {
                        Console.WriteLine ( result + " " + " .... really? " + " Only above zero Numbers Please .. try again");
                    }

                }
                else
                {
                       Console.WriteLine(" .... really? " + " Please enter just a number.. no words .. try again");
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
