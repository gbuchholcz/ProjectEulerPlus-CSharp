using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler9
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
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());

                int maxProd = -1;

                for (int b = N % 2 == 0 ? N / 2 - 1 : N / 2; b >= N >> 2; --b)
                {
                    int a = N - N * N / 2 / (N - b);
                    if (b < a) break;
                    int csqr = a * a + b * b;
                    int c = Convert.ToInt32(Math.Sqrt(csqr));
                    if (a + b + c != N || a * a + b * b != c * c) continue;
                    int newProd = a * b * c;
                    if (newProd > maxProd)
                    {
                        maxProd = newProd;
                    }
                }
                output.WriteLine(maxProd);
            }
        }

        public static void Test()
        {
            string inputData = @"2
                                    12
                                    4";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
