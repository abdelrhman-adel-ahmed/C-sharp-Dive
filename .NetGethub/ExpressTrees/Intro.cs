﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExpressTrees
{
    public class Intro
    {
        public static void run()
        {
            /*
             * .net doesnot know any thing about this c# syntax , .net can run any thing that is msil 
             so before that we need to convert thast to syntax that ,net jit can compile
            static bool ssdasdas(int i)
            {
            return i>5;
            }
            ==== > this code when transelated to msil .net can understand it just a function

            Surprise not always the compiler convert the lambda experssion to a function !! 
             */
            Func<int, bool> test = i => i > 5;
            Console.WriteLine(test(4));
            Console.WriteLine(test(6));
            MethodInfo n = test.Method;
            Console.WriteLine(n.Name) ;
          

        }
     
    }
}
