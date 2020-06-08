using System;
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
            d1.DrawNextNum();
            d1.DrawNextNum();
            ///d1.DrawStorage.ForEach(Console.WriteLine);//this is a really cool way of doing it because this methid chooses the right type for the list.
            Interface i1 = new Interface();
            i1.draw.DrawNextNum();
            i1.draw.DrawNextNum();
            i1.draw.DrawNextNum();
            i1.draw.DrawNextNum();
            i1.draw.DrawNextNum();
            i1.draw.DrawNextNum();
            i1.draw.DrawNextNum();
            i1.checkNuminList();



        }
    }


}
