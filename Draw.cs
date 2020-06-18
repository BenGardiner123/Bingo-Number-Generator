using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo_Number_Generator
{
    class Draw
    {

        public int upperlimit;
        public List<int> DrawStorage;
        public List<int> userBulkEntryList; // this is to use when they bulk enter their numbers

        Random rand = new Random();

        public Draw(int limit)
        {
            this.upperlimit = limit;
            this.DrawStorage = new List<int>();
            this.userBulkEntryList = new List<int>();

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
                Console.WriteLine("Please make a selection");

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
                ///2.	Upon pressing “1” a new number is drawn
                ///i.	No duplicate numbers should be drawn
                ///ii.	No negative numbers should be drawn
                ///im thinking i use the same functionality of the upper limit menu to try and force correct input.
                if (validInput == 1)
                {
                    DrawNextNum();
                    //DrawNextNum includes the mainMenu function at the end so it always returns to the main menu here.
                }
                else if (validInput == 2)
                {
                   menuOption2(); 
                }
                /// 4.	Upon pressing “3” user is prompted to enter numbers one by one to check if they have been drawn
                else if (validInput == 3)
                {
                   menuOption3();
                }                
                else if (validInput == 4)
                {
                    Console.WriteLine("Thanks for playing.. see you next time");
                    break;
                }

            }


        }

        

        public void menuOption2()
        {
            bool menuCheck = false; // again set up the exit trigger
                    while (!menuCheck)
                    {
                        
                        Console.WriteLine("1. Print all numbers in the order that they were drawn");
                        Console.WriteLine("2. Print all numbers in numerical order");
                        Console.WriteLine("3. To return to the main menu");
                        string userChoice = Console.ReadLine(); // need to try parse

                        int result = 0;
                        if (int.TryParse(userChoice, out result)) //so if the user input is parseable its a number
                        {
                            
                            if (result <= 0)
                            {
                                Console.WriteLine (userChoice + "....oh.... thats not a valid input" + " Only the numbers 1, 2 or 3 - please... try again");
                            }
                            if (result == 1)
                            {
                                viewAllDrawnnums();
                            }
                            if (result == 2)
                            {
                                ///some function that orders DrawStorage - but i need somethnig that doesnt mess up the original order.
                                viewAllNumsinOrder();
                            }
                            else if (result == 3)
                            {
                                menuCheck = true;
                                mainMenu();
                            }


                        }
                        else /// so if the parse fails it must be letters or something else
                        {
                            Console.WriteLine (userChoice + "....oh.... thats not a valid input" + " only input the number 1, 2 or 3 - please... try again");
                        }




                    }
        }

        public void menuOption3()
        {
            if (DrawStorage.Count==0)
            {
                Console.WriteLine("Whoa...Whoa...Whoa....you havent even drawn a number yet" + " Please head back to the main menu and first draw a number..");
                mainMenu();
            } 
            else 
            {
                checkNuminList();
            }
        }




        public void viewAllDrawnnums()
        {
        //console writlien 1 option as they were drawn
        this.DrawStorage.ForEach(Console.WriteLine);
        ///option two they get srtoed into numercial order - might have to make a new list to copy them and sort them
        }

         public void viewAllNumsinOrder()
        {
            //from dotnetpearls - - - this is a LINQ query same way we use SQL but in c# baby! the just iterate over the nums stored in the var i created.
            var ordered = from nums in DrawStorage
                          orderby nums ascending
                          select nums;

            foreach (int value in ordered)
            {
                Console.WriteLine(value);
            }
            
        

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
            Console.WriteLine("\n" + randnum + " has just been drawn");
            ///SortedOrder.add(radnnum); this list then gets sorted when you access it to print for option3.ii 
            mainMenu(); ///beause of the nature of drawing the number they need to go back to the top menu everytime they draw.!-- 

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
                        Console.WriteLine("\n" + result + " excellent choice " + result + " is a fine number");
                        goOn = true; /// so if the loop gets here it's passed the parse test.!-- We would then want the loop to exit
                        upperlimit = result;
                    }
                    else // if it comes here that means that the result was not greater than 0... so a -1 etc... we cant have that so
                    {
                        Console.WriteLine ( result + " " + " .... really? Only positive numbers please .. try again");
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
            bool goOn = true; //exit value
            while (goOn)
            {
                Console.WriteLine("Please enter your number to check if it has been drawn..");
                string targetInt = Console.ReadLine();
                int number;
                if (Int32.TryParse(targetInt, out number)) /// again this test will find out if it is indeed a # - if not the test fails and we can re-loop 
                {
                        
                        int index = DrawStorage.IndexOf(number); ///this checks ans sees if the targetint is in the list

                        if (number <= 0) /// this checks user input to make sure it's not negative - if they got this far in the code the parse worked and its a number.!--
                        {
                            Console.WriteLine ( number + " " + " .... really? " + " Only positive numbers please .. try again");
                            continue;
                        }
                        if (index >= 0)// index defined above - it accessing drawstorage to see if the userinput number is there. Mits returning the index of it which must be 0 or greater if it is there, so then it will return true.
                        {
                            Console.WriteLine( number + " Has been located, and i can confirm it has been drawn previously");
                        }
                        else
                        {
                            Console.WriteLine("..-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.");
                            Console.WriteLine("\nYour number has not been drawn - its fresh");
                        }
                        
                        bool goON = false;
                        while (!goON)
                        {
                            Console.WriteLine("\n1. Check another number ");
                            Console.WriteLine("2. Return to main menu");
                            string userInput = Console.ReadLine();
                            int userMenuNum; // this stores the value form my tryParse
                            if (Int32.TryParse(userInput, out userMenuNum)) /// again this test will find out if it is indeed a # - if not the test fails and we can re-loop 
                            {
                                if (userMenuNum <= 0)
                                {
                                    Console.WriteLine(userMenuNum + " .... really? " + " Only numbers above zero please .. try again");
                                }
                                if (userMenuNum == 1)
                                {
                                    checkNuminList();
                                }
                                if (userMenuNum == 2)
                                {
                                    goON = true;
                                    mainMenu();
                                } 
                                else
                                {
                                    Console.WriteLine(userMenuNum + " .... really? " + " Only menu choices please..");
                                }
                            }
                            else
                            {
                                Console.WriteLine(userInput + ".... really? " + " Please enter just a number.. no words or other funny stuff .. try again");
                            }
                            
                        }
               
                }
                else
                {
                    Console.WriteLine( ".... really? " + " Please enter just a number.. no words or other funny stuff .. try again");
                }    
            }
        }

    }


}