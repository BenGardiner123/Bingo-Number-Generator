using System;
using System.Linq;

namespace Bingo_Number_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            ///so the functionality is inside the draw class - to sue any of the functions i need to instatiate the class 1st here 
            //and then call its functions as required.

            Draw d1 = new Draw(99);
            ///1.	Upon starting the program should ask for the upper limit of numbers to be drawn
             ///i.	Program should not accept non-numeric input
            ///ii.	Program should not accept negative numbers
            d1.getupperLimit();// upper liit then calls main menu

        }
    }


}
