using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Reflections
{

    class TestAttribute : Attribute { }
    class TestMethodAttribue : Attribute { }


    [TestAttribute] //attribute word not necessary compiler will add it
    class MyTestSuite 
    {
        public void helper()
        {
            //intialized somthings in the test functions (setup function for testing)
            Console.WriteLine("this method will not be invoked because it doesnot have TestMethodAttribue on it");
        }
        [TestMethodAttribue]
        public void MyTest1()
        {
            Console.WriteLine("perform test1");
        }
        [TestMethodAttribue]
        public void MyTest2()
        {
            Console.WriteLine("perform test2");

        }
    }
    

    class ReflectionAttributeExample
    {
        /*we will use those attribute that is just sit in top of our functions its just meta data 
         * that get created that we can access later to decide if we want to do somthing 
         * to however have those meta data like what we do here to see how have the test attribut
         * to automatically call them and not any thing else ,to act upon them the way
         * we want to , we want automatic way to execute the two methods mytest1 mytest2 ,and not automatically
         * execute the helper method ,so we can use the attribute to (reflect) upon our self ,access the assembly
         * types then see what have custome attribute 
        */

        public static void run()
        {
            //we can use linq to simplifie this shit
            foreach (Type e in Assembly.GetExecutingAssembly().GetTypes())
                foreach (Attribute a in e.GetCustomAttributes(false))
                {
                    if (a is TestAttribute)
                    {
                        Console.WriteLine("running test suite " + e.Name);
                        foreach (MethodInfo m in e.GetMethods())
                        {
                            foreach (Attribute z in m.GetCustomAttributes(false))
                            if(z is TestMethodAttribue)
                            {
                                object testsuiteinstance = Activator.CreateInstance(e);
                                m.Invoke(testsuiteinstance, new object[0]);
                                    
                            }
                        }
                    }
                }
        }
    }
}
