using System;

namespace codality
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {6, 1, 4, 6, 3, 2, 7, 4};
            int K = 3;
            int L = 2;

            solution sol = new solution();
            Console.WriteLine(sol.sol(A, K, L));

            Console.ReadKey();
        }
    }
}
