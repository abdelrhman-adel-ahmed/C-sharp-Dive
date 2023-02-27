using System;
using System.Collections.Generic;
using System.Text;

namespace first_test
{
    class types
    {

         public int max = unchecked (int.MaxValue + 20); //without unckecked it will produce and errro of overflow
        //what it will do here is go around and start from the negative values !
        // int max 011111111 11111111 11111111 11111111 --> int max if we add 20 to it, it will give negative number
        //the sign bit will become 1 (negative)

        public int max_long = unchecked ((int) long.MaxValue);
        //will give -1
        // 011111111 11111111 11111111 11111111 11111111 11111111 11111111 11111111 -->max long 
        // i we convert this to int: 4 bytes that mean it will cut off 4 bytes from the long start from the 
        // msb so we left with 11111111 11111111 11111111 11111111 --> -1 in 2s compliment

        public void type_in_csharp()
            {
            int imp=10;
            long y = imp; //from small to big (no loss) implict

            long exp = 20; //from big to small ,potintial loss (explicit)
            int x = (int)exp;
            }
        
        public void widening_nuances() //اتساع الفروق الدقيقة
        {
            byte x = 10; //byte is unsigned 0 --255, sbyte is signed from -128 to 127
            byte y = 20;
            // even we just add byte and byte into a byte c# do some shit of widening  here it wide it to int
            //same with short wich is 16 bit 
            byte result = (byte)(x + y);  //or int result =x+y; 
        }

        public void non_integer()
        {
            float mm = .1f; //suffix with f for float if not it will be double (64 float) 
            float jk = .2f;
            float lll = mm + jk;
            Console.WriteLine("----------------------------");
            Console.WriteLine("float");
            Console.WriteLine(lll);
            Console.WriteLine(.1+.2);
            Console.WriteLine(.1 + .2 == lll); 
            Console.WriteLine(.3 == lll);
            Console.WriteLine("----------------------------");

            decimal x = .1m;
            decimal y = .2m;
            decimal result = x + y;
            Console.WriteLine("Decimal");
            Console.WriteLine(result);
            Console.WriteLine(.1 + .2 == (double)result);//when compiler use non_intger on fly in convert it to double
            Console.WriteLine(.3 == (double)result);
            Console.WriteLine("----------------------------");

            double x1 = .1;
            double x2 = .2;
            double result2 = x1 + x2;
            Console.WriteLine("double");
            Console.WriteLine(result2);
            Console.WriteLine(.1 + .2 == result2);
            Console.WriteLine(.3 == result2);
            Console.WriteLine("----------------------------");

        }
    }



    class Conversion_base
    {
        public int basevalue;
        public void basemethod()
        {
            Console.WriteLine("base method");
        }
    }
    class Conversion_dirve:Conversion_base
    {
        public float drivevalue;
        public void drivemethod()
        {
            Console.WriteLine("drive method");
           
            object x = 10;
            //compile time will allow this but run time checking will not allow this ,you have to unbox to
            //the same type you box to.
            //float y = (float)x; 



        }
    }

}



