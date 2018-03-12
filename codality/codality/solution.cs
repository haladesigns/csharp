using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace codality
{
    public class solution
    {
        public int sol(int[] A, int K, int L)
        {
            int result = 0;
            int maxAlice = 0;
            int maxBob = 0;
            int total = 0;

            if ((K + L) > A.Length)
            {
                result = -1;
            }
            else
            {
                try
                {
                    int tempMaxAlice = 0;
                    int tempMaxBob = 0;

                    for (int i = 0; i < A.Length - 3; i++)
                    {
                        if(i + 4 >  A.Length){
                            break;
                        }else
                        {
                            maxAlice = A[i] + A[i + 1] + A[i + 2];

                            for (int j = i + 3; i < A.Length - 1; j++)
                            {
                                if (j + 1 > A.Length - 1)
                                {
                                    break;
                                }
                                else
                                {
                                    maxBob = A[j] + A[j + 1];
                                    if (maxBob > tempMaxBob) tempMaxBob = maxBob;
                                }
                            }

                            if (maxAlice > tempMaxAlice) tempMaxAlice = maxAlice;
                        }
                    }

                    result = tempMaxAlice + maxBob;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //return -1;
                }
            }

            return result;
        }
    }
}
