using System;
using functionalcsharp.ch3;

namespace functionalcsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 251, 423, 663, 144, 375 };
            bsort1.sortMe(intArray);
            Console.WriteLine("\n----------------------\n");

            Object[] objectArray = { 251, 423, 663, 144, 375 };
            bsort2.Sort(objectArray, anonymousfunclambda.ilt_int);
            Console.WriteLine("\n----------------------\n");

            Console.WriteLine("\n---------Extension Methods-------------\n");
            var stringval = "My string";
            int[] myObjectArray = { 251, 423, 663, 144, 375 };
            stringval.printType(); //this will cause error if you stick it in a console.writeline
            Console.WriteLine(5.square());
            Console.WriteLine(myObjectArray.secondElement());


            Console.WriteLine("\n---------Generic Functions----------\n");
            OutputThing(42); //prints 42
            OutputThing("Hellow World"); //prints Hellow World


            Console.ReadKey();
        }

        static void OutputThing<T>(T thing)
        {
            Console.WriteLine("Thing  { 0}", thing);
        }
    }
}
