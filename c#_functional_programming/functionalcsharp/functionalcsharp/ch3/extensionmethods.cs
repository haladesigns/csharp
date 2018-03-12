using System;
using System.Collections.Generic;
using System.Text;

namespace functionalcsharp.ch3
{
    static class extensionmethods
    {
        public static void printType(this Object thing)
        {
            Console.WriteLine(thing.GetType().FullName);
        }

        public static double square(this int x)
        {
            return Math.Pow(x, 2);
        }

        public static T secondElement<T>(this IList<T> collection)
        {
            return collection[1];
        }
    }
}
