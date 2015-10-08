using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler20
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            int[] n1 = new int[3001]; //the last element holds the length of the number
            int[] n2 = new int[3001];
            int[] tmp;
            int[] results = new int[1001];
            results[0] = 1;
            results[1] = 1;
            n2[3000] = 0;
            n1[3000] = 1;
            n1[0] = 1;

            for (int k = 2; k < 1001; ++k)
            {
                int sum = 0;
                int carry = 0;
                n2[3000] = n1[3000];
                for (int i = 0; i < n1[3000]; ++i)
                {
                    int d = n1[i] * k + carry;
                    n2[i] = d % 10;
                    sum += n2[i];
                    carry = d / 10;
                }

                while (carry != 0)
                {
                    n2[n2[3000]++] = carry % 10;
                    sum += carry % 10;
                    carry /= 10;
                }
                results[k] = sum;
                tmp = n1;
                n1 = n2;
                n2 = tmp;
            }


            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                output.WriteLine(results[N]);
            }
        }

        public static void Test()
        {
            string inputData = @"2
3
6";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
