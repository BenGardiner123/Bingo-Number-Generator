﻿using System;
using System.Linq;

namespace Bingo_Number_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
    

            Draw d1 = new Draw();
            d1.getupperLimit();
            
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();
            d1.DrawNextNum();

            ///d1.DrawStorage.ForEach(Console.WriteLine);//this is a really cool way of doing it because this methid chooses the right type for the list.
            
           
             



        }
    }


}
