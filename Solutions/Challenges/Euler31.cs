using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler31
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            long[] coinValues = new long[] { 1, 2, 5, 10, 20, 50, 100, 200 };
            long[,] sumMaxCoinValueCombinations = new long[100000 + 1, coinValues.Length];
            long mod = 1000000007;

            for (int i = 0; i < coinValues.Length; ++i)
            {
                sumMaxCoinValueCombinations[0, i] = 1;
            }

            for (int i = 1; i < sumMaxCoinValueCombinations.GetLength(0); ++i)
            {
                for (int j = 0; j < coinValues.Length; ++j)
                {
                   long result = 0;
                   if (j == 0)
                   {
                       result = 1;
                   }
                   else
                   {
                       result = sumMaxCoinValueCombinations[i, j - 1];
                       if (i >= coinValues[j])
                       {
                           result += sumMaxCoinValueCombinations[i - coinValues[j], j];
                           result %= mod;
                       }
                   }
                   sumMaxCoinValueCombinations[i, j] = result;

                }

            }

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                output.WriteLine(sumMaxCoinValueCombinations[N, coinValues.Length -1]);
            }

        }

        public static void Test()
        {
            string inputData = @"3
10 
15
20";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
