using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

    interface test { }
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("-------------------Extension methods-------------------");
            //ExtensionMethods.run();


            //Console.WriteLine("-------------------how Extension methods------------------");
            //ThisInCsharp.run();


            //Console.WriteLine("-------------------Extension methods Example------------------");
            //ExtensionMethodExample.run();


            //Console.WriteLine("-------------------LINQ 2 out own extension------------------");
            //Writing_Your_Own_LINQ_Extension_Method.run();

            //Console.WriteLine("-------------------LINQ 1------------------");
            //Linq1.run();

            //Console.WriteLine("-------------------LINQ_Degenerate_Select_Clauses------------------");
            //LINQ_Degenerate_Select_Clauses.run();

            //Console.WriteLine("-------------------Compiler_Translation_of_a_Larger_Example------------------");
            //Compiler_Translation_of_a_Larger_Example.run();


            //Console.WriteLine("-------------------Introduction_To_Deferred_Execution------------------");
            //Introduction_To_Deferred_Execution.run();



            // Console.WriteLine("-------------------introduction_to_deferred_execution 2------------------");
            // Introduction_To_Deferred_Execution_2.run();

            //Console.WriteLine("-------------------Deferred_Execution___Assembly_Line------------------");
            //Deferred_Execution___Assembly_Line.run();


            //Console.WriteLine("-------------------runtime_created_assembly_lines------------------");
            //Runtime_Created_Assembly_Lines.run();

            //Console.WriteLine("-------------------Northwind_Database------------------");
            //Northwind_Database.run();


            //Console.WriteLine("-------------------Projection------------------");
            //Projection.run();


            //Console.WriteLine("-------------------orderby------------------");
            //orderby.run();

            // Console.WriteLine("-------------------Random_Ordering------------------");
            // Random_Ordering.run();


            //Console.WriteLine(default(Runtime_Created_Assembly_Lines));

            try
            {
                await MultipleTasks();
                //await MyAsyncMethod();
            }
            catch (AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                {
                    Console.WriteLine("Show my exception:");
                    Console.WriteLine(item.Message);
                }
                //Console.WriteLine("Show my exception:");
                //Console.WriteLine(ex.Message);
            }
            catch(AppDomainUnloadedException)
            {

            }
            Console.ReadLine();
        }
        private static async Task MultipleTasks()
        {
            Task task = Task.Run(() => throw new ArgumentException("Exception Task 1"));
            Task secondTask = Task.Run(() => throw new NullReferenceException("Exception Task 2"));

            Task.WaitAll(task, secondTask);
        }
        private static async Task MyAsyncMethod()
        {
            throw new ArgumentException("Exception from MyAsyncMethod");
        }
    }
}
