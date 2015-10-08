using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler16
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
            int[] n1 = new int[10002]; //10001 number from 0 to 10000 and the length
            int[] n2 = new int[10002];
            int[] tmp;
            int[] results = new int[10001];
            n2[10001] = 0;
            n1[10001] = 1;
            n1[0] = 1;
            

            for (int k = 1; k < 10001; ++k)
            {
                int sum = 0;
                int carry = 0;
                n2[10001] = n1[10001];
                for (int i = 0; i < n1[10001]; ++i)
                {
                    int d = n1[i] * 2 % 10;
                    n2[i] = d + carry;
                    sum += d + carry;
                    carry = n1[i] * 2 / 10;
                    
                }
                if (carry != 0)
                {
                    n2[n1[10001]] = carry;
                    sum += carry;
                    ++n2[10001];
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
            string inputData = @"3
3
4
7";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
