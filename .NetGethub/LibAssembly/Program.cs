using System;

namespace LibAssembly
{

    public interface test
    {

    }
    public class Sample
    {
        public static string Print()
        {
            return "hello from the other side";
        }
      
    }
    class programe
    {
        public static void main()
        {
            Console.WriteLine(default(test));
        }
    }
}
