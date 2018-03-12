using System;
using System.Collections.Generic;
using System.Text;

namespace functionalcsharp.ch3
{
    class bsort1
    {
        public void test()
        {
            Console.WriteLine("This is a test !");
            Console.ReadKey();
        }

        public static void sortMe(int[] values)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int x = 0; x < values.Length - 1; x++)
                {
                    if (values[x] > values[x + 1])
                    {
                        int temp = values[x];
                        values[x] = values[x + 1];
                        values[x + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            foreach (int x in values)
            {
                Console.WriteLine(x);
            }
        }
    }

    class bsort2
    {
        //public delegate bool IsAGreaterThanBDelegate(object a, object b);

        public static void Sort(Object[] values, Func<Object, Object, bool> isAGreaterThanB)
        {
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 0; i < values.Length - 1; i++)
                {
                    if (isAGreaterThanB(values[i], values[i + 1]))
                    {
                        Object temp = values[i];
                        values[i] = values[i + 1];
                        values[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            for (int x = 0; x < values.Length; x++)
            {
                Console.WriteLine(values[x]);
            }
        }
    }
}
